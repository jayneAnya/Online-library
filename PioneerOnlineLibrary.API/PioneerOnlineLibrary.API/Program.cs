using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PioneerOnlineLibrary.Core.Interface;
using PioneerOnlineLibrary.Core.Services;
using PioneerOnlineLibrary.Domain.Model;
using PioneerOnlineLibrary.Infrastructure;
using PioneerOnlineLibrary.Infrastructure.Interface;
using PioneerOnlineLibrary.Infrastructure.Repository;
using System.Text;

namespace PioneerOnlineLibrary.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDbContext<PioneerDbContext>(
			  options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDataBase"), b => b.MigrationsAssembly("PioneerOnlineLibrary.API")));

            

            builder.Services.AddScoped<IBookService, BookService> ();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            

            //builder.Services.AddTransient<IImageService, ImageService>();
            //builder.Services.AddTransient<Cloudinary, ImageService>();

            builder.Services.AddTransient<IImageService, ImageService>(
            serviceProvider => new ImageService(
            serviceProvider.GetRequiredService<Cloudinary>()
            
            ));


            //For Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>()
				.AddEntityFrameworkStores<PioneerDbContext>()
				.AddDefaultTokenProviders();

			// Adding Authentication
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

			})

			// Adding Jwt Bearer
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = builder.Configuration["JWT:ValiAudience"],
					ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))

				};
			});

            var cloudinaryConfig = builder.Configuration.GetSection("Cloudinary").Get<CloudinarySettings>();
            var cloudinary = new Cloudinary(new Account(cloudinaryConfig.CloudName, cloudinaryConfig.ApiKey, cloudinaryConfig.ApiSecret));



            builder.Services.AddSingleton(cloudinary);



            builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Book API",
                    Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
                });
                // To Enable authorization using Swagger (JWT)
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter ‘Bearer’ [space] and then your valid token in the text input below.\\r\\n\\r\\nExample: \\”Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\\",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {

                    new OpenApiSecurityScheme
                    {

                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }

                    },
                    new string[] {}
                    }

                }) ;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API V1");
                    //c.RoutePrefix = string.Empty;
                });
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();

                app.Run();

                
            }
        }
	}
}