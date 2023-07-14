using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomalizeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstEmail = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PresentEmail = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "14ee1a43-5970-4108-b1ed-45e669bcdf83", "", "ADMIN", "Admin" },
                    { "88a3020e-e0e0-4abb-ad1c-63c52a0364a2", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "LastName", "PasswordHash", "PresentEmail", "RoleId", "UserName" },
                values: new object[,]
                {
                    { "a7c915d6-d121-4eed-acd9-52628530ae48", new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3100), new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3111), "test001@gmail.com", "test", false, "account", "$2a$10$XD1mRo8wZ/h9aJtAD0i2yOmR3PPKb/3R4bIcwHaWu6gV5RAh3c7pG", "test001@gmail.com", "88a3020e-e0e0-4abb-ad1c-63c52a0364a2", "testVersion_0001" },
                    { "e7d048ec-81c2-4541-ac58-bf02f69f6721", new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3118), new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3119), "admin001@gmail.com", "Admin", false, "account", "$2a$10$3cfpf9Kd5RWjGwIJB6acRuCJErWLuvtrrbys2OwxDJZNnRMUtGTha", "admin001@gmail.com", "14ee1a43-5970-4108-b1ed-45e669bcdf83", "adminVersion_0001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
