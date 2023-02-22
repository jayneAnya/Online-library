using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PioneerOnlineLibrary.API.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    PublicationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "BookCategory", "Description", "Genre", "ISBN", "ImageURL", "IsAvailable", "Language", "Pages", "Price", "PublicationDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 2, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 3, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 4, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 5, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 6, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 7, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 8, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 9, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 10, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 11, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 12, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 13, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 14, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 15, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" },
                    { 16, "Aaron Blabey", "Most Recent", "The Latin cogito, ergo sum, usually translated into English as \"I think, therefore I am\", is the \"first principle\" of René Descartes's philosophy. He originally published it in French as je pense, donc je suis in his 1637 Discourse on the Method, so as to reach a wider audience than Latin would have allowed. It later appeared in Latin in his Principles of Philosophy, and a similar phrase also featured prominently in his Meditations on First Philosophy.", "Comedy", "978-0545912402", "http://res.cloudinary.com/dresodocz/image/upload/jwbgka7d6f9mvzipj9rn", true, "English", 100, 19m, "26-11-2016", "Scholastic Press", "The Bad Guys" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
