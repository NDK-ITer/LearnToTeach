using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "ac753d87-7767-4962-a8af-21ed07fa61ed", "", "ADMIN", "Admin" },
                    { "e48104f6-74c3-4576-bdaf-13de5e9410b6", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "IsVerified", "LastName", "PasswordHash", "PhoneNumber", "PresentEmail", "RoleId", "TokenAccess", "UserName", "VerifiedDate" },
                values: new object[,]
                {
                    { "193ba283-bf34-40ad-a3be-10b1780cba0e", "", new DateTime(2023, 11, 2, 11, 13, 33, 75, DateTimeKind.Local).AddTicks(2323), new DateTime(2023, 11, 2, 11, 13, 33, 75, DateTimeKind.Local).AddTicks(2336), "test001@gmail.com", "test", false, true, "account", "nSUQ/133didCpNJLsvcLvQ==", "0123456789", "test001@gmail.com", "e48104f6-74c3-4576-bdaf-13de5e9410b6", "F3345E54FC54739F106961F5A5293CCE9E325B8C0E1D43A7723CA86B10D21AB4D60123823C2BBA787C82BED791095972C11E938D2C088EF46ED1443EB7A26CC4", "testVersion_0001", new DateTime(2023, 11, 2, 11, 13, 33, 75, DateTimeKind.Local).AddTicks(2387) },
                    { "2c75293b-f8e5-4862-9b13-5894a64895cd", "", new DateTime(2023, 11, 2, 11, 13, 33, 75, DateTimeKind.Local).AddTicks(2481), new DateTime(2023, 11, 2, 11, 13, 33, 75, DateTimeKind.Local).AddTicks(2482), "admin001@gmail.com", "Admin", false, true, "account", "VWBU8/+H4em26o8A92n+Tg==", "0123456789", "admin001@gmail.com", "ac753d87-7767-4962-a8af-21ed07fa61ed", "A6482AD8D7A03B81246F465A4EEC8C9835545C042FA665837B58ED01EED735202E77023E97CECAE5C59359523A5EA99D61CF90492C079E5EB6AE186202CAFA8F", "adminVersion_0001", new DateTime(2023, 11, 2, 11, 13, 33, 75, DateTimeKind.Local).AddTicks(2487) }
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
