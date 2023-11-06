using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserServiceinitial : Migration
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
                    NormalizeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TokenAccess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ClassroomInfor",
                columns: table => new
                {
                    IdClassroom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsHost = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomInfor", x => new { x.IdUser, x.IdClassroom });
                    table.ForeignKey(
                        name: "FK_ClassroomInfor_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NormalizeName" },
                values: new object[,]
                {
                    { "3bfa0033-ec25-4271-9ca3-7f158bf5dab2", "", "ADMIN", "Admin" },
                    { "fd62b292-ec16-4c4b-9e83-907a3e579041", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "IsVerified", "LastName", "PasswordHash", "PhoneNumber", "PresentEmail", "RoleId", "TokenAccess", "UserName", "VerifiedDate" },
                values: new object[,]
                {
                    { "193ba283-bf34-40ad-a3be-10b1780cba0e", "", new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7063), new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7075), "test001@gmail.com", "test", false, true, "account", "nSUQ/133didCpNJLsvcLvQ==", "0123456789", "test001@gmail.com", "fd62b292-ec16-4c4b-9e83-907a3e579041", "4C1745F0002B41D8CBFC286958F1B825F09F2CDE8A1359DC43C43401532E0EA09E76BBA37D49E913BC6590F197E2A2CB42E2EDFF95F8037F41220E5267737150", "testVersion_0001", new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7135) },
                    { "2c75293b-f8e5-4862-9b13-5894a64895cd", "", new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7223), new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7223), "admin001@gmail.com", "Admin", false, true, "account", "VWBU8/+H4em26o8A92n+Tg==", "0123456789", "admin001@gmail.com", "3bfa0033-ec25-4271-9ca3-7f158bf5dab2", "62BAEE704AD866A50E5AFCBEBCB040BBF73D19657FF692EAB3B5C56D18A94C1C3D4A810A062F84AA21DC3A2631DD289925888731DD6E198D894762D3DCEEF424", "adminVersion_0001", new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7226) }
                });

            migrationBuilder.InsertData(
                table: "ClassroomInfor",
                columns: new[] { "IdClassroom", "IdUser", "Description", "IsHost", "Name" },
                values: new object[,]
                {
                    { "ee546ce7-842a-4dee-86d0-0db1ff3b64b4", "193ba283-bf34-40ad-a3be-10b1780cba0e", "", true, "Class_1" },
                    { "0a006921-b4a4-40de-a1e6-9497daf09a2f", "2c75293b-f8e5-4862-9b13-5894a64895cd", "", true, "Class_2" }
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
                name: "ClassroomInfor");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
