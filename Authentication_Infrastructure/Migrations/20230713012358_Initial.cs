using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    { "58908000-acc4-4b47-995b-4f49f685a44a", "", "USER", "User" },
                    { "74d42486-a97c-4055-b7ff-fe99aee6ce28", "", "ADMIN", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "LastName", "PasswordHash", "PresentEmail", "RoleId", "UserName" },
                values: new object[,]
                {
                    { "401561be-c57d-464f-bc09-b155400d4ba4", new DateTime(2023, 7, 13, 8, 23, 58, 95, DateTimeKind.Local).AddTicks(2185), new DateTime(2023, 7, 13, 8, 23, 58, 95, DateTimeKind.Local).AddTicks(2185), "admin001@gmail.com", "Admin", false, "account", "$2a$10$3cfpf9Kd5RWjGwIJB6acRuCJErWLuvtrrbys2OwxDJZNnRMUtGTha", "admin001@gmail.com", "74d42486-a97c-4055-b7ff-fe99aee6ce28", "adminVersion_0001" },
                    { "be58dd14-3a95-4c0e-8f32-89e9c6d8558b", new DateTime(2023, 7, 13, 8, 23, 58, 95, DateTimeKind.Local).AddTicks(2168), new DateTime(2023, 7, 13, 8, 23, 58, 95, DateTimeKind.Local).AddTicks(2180), "test001@gmail.com", "test", false, "account", "$2a$10$XD1mRo8wZ/h9aJtAD0i2yOmR3PPKb/3R4bIcwHaWu6gV5RAh3c7pG", "test001@gmail.com", "58908000-acc4-4b47-995b-4f49f685a44a", "testVersion_0001" }
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
