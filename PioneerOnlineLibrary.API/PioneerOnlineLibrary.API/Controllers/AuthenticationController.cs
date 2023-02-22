using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PioneerOnlineLibrary.API.ViewModels;
using PioneerOnlineLibrary.Domain.Enum;
using PioneerOnlineLibrary.Domain.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace PioneerOnlineLibrary.API.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<AppUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IConfiguration _configuration;

		public AuthenticationController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			_configuration = configuration;
		}

		[HttpPost]
		[Route("register")]
       // [Authorize(Roles = "User")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
		{
			var userExist = await userManager.FindByNameAsync(model.UserName);
			if (userExist != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "user already exist" });
			}

			AppUser user = new AppUser()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.UserName,
			};

			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed. Please try again." });
			}
			return Ok(new Response { Status = "Success", Message = "User created Successfully" });

		}



		[HttpPost]
		[Route("register-admin")]
		//[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
		{
			var userExist = await userManager.FindByNameAsync(model.UserName);
			if (userExist != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "user already exist" });
			}

			AppUser user = new AppUser()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.UserName,
			};

			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed. Please try again." });
			}
			if (!await roleManager.RoleExistsAsync(Role.Admin.ToString()))
				await roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
			if (!await roleManager.RoleExistsAsync(Role.RegularUser.ToString()))
				await roleManager.CreateAsync(new IdentityRole(Role.RegularUser.ToString()));

			if (await roleManager.RoleExistsAsync(Role.Admin.ToString()))
			{
				await userManager.AddToRoleAsync(user, Role.Admin.ToString());
			}
			return Ok(new Response { Status = "Success", Message = "User created successfully" });


		}



        [HttpPut]
        [Route("update")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] AppUser user)
        {
            var userExist = await userManager.FindByNameAsync(user.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "user exist" });
            }


			var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Updating user failed. Please try again." });
            }
            return Ok(new Response { Status = "Success", Message = "User updated Successfully" });

        }

        [HttpDelete]
        [Route("delete")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody] AppUser user)
        {
            var userExist = await userManager.FindByNameAsync(user.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "user exist" });
            }


            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Updating user failed. Please try again." });
            }
            return NoContent();

        }



        [HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel model)
		{
			var user = await userManager.FindByNameAsync(model.UserName);
			if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
			{
				var userRoles = await userManager.GetRolesAsync(user);
				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, model.UserName),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

				foreach (var userRole in userRoles)
				{
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));
				}

				var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

				var token = new JwtSecurityToken(
					issuer: _configuration["JWT:ValidIssuer"],
					audience: _configuration["JWT:ValidAudience"],
					expires: DateTime.Now.AddHours(3),
					claims: authClaims,
					signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
					);
				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					expiration = token.ValidTo
				});
			}
			return Unauthorized();
		}
	}
}
