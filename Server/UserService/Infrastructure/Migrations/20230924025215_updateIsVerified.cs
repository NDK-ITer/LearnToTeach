using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateIsVerified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "71c27472-2948-483e-a54e-4d2a2d31da57");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "d8b8ec79-cd6e-433e-8de6-7b7af589af7c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "527428c3-5f67-42bc-a573-f11471706589");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "77d0ae4e-0466-4a77-8862-0d634371a049");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "2c077bce-1438-46e3-b9be-2d7a8690dc3c", "", "ADMIN", "Admin" },
                    { "dc12ee81-3add-46d8-9709-06f303a1adcd", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "IsVerified", "LastName", "PasswordHash", "PresentEmail", "RoleId", "TokenAccess", "UserName", "VerifiedDate" },
                values: new object[,]
                {
                    { "2acdc2c7-2738-4caf-97a5-d2cb2d720db3", new DateTime(2023, 9, 24, 9, 52, 14, 943, DateTimeKind.Local).AddTicks(4348), new DateTime(2023, 9, 24, 9, 52, 14, 943, DateTimeKind.Local).AddTicks(4349), "admin001@gmail.com", "Admin", false, true, "account", "VWBU8/+H4em26o8A92n+Tg==", "admin001@gmail.com", "2c077bce-1438-46e3-b9be-2d7a8690dc3c", "", "adminVersion_0001", new DateTime(2023, 9, 24, 9, 52, 14, 943, DateTimeKind.Local).AddTicks(4349) },
                    { "eb45a668-3b11-4ce7-9e41-08609d2d21d4", new DateTime(2023, 9, 24, 9, 52, 14, 943, DateTimeKind.Local).AddTicks(4237), new DateTime(2023, 9, 24, 9, 52, 14, 943, DateTimeKind.Local).AddTicks(4250), "test001@gmail.com", "test", false, true, "account", "nSUQ/133didCpNJLsvcLvQ==", "test001@gmail.com", "dc12ee81-3add-46d8-9709-06f303a1adcd", "", "testVersion_0001", new DateTime(2023, 9, 24, 9, 52, 14, 943, DateTimeKind.Local).AddTicks(4251) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2acdc2c7-2738-4caf-97a5-d2cb2d720db3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "eb45a668-3b11-4ce7-9e41-08609d2d21d4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c077bce-1438-46e3-b9be-2d7a8690dc3c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dc12ee81-3add-46d8-9709-06f303a1adcd");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "527428c3-5f67-42bc-a573-f11471706589", "", "USER", "User" },
                    { "77d0ae4e-0466-4a77-8862-0d634371a049", "", "ADMIN", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "LastName", "PasswordHash", "PresentEmail", "RoleId", "TokenAccess", "UserName", "VerifiedDate" },
                values: new object[,]
                {
                    { "71c27472-2948-483e-a54e-4d2a2d31da57", new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9316), new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9316), "admin001@gmail.com", "Admin", false, "account", "VWBU8/+H4em26o8A92n+Tg==", "admin001@gmail.com", "77d0ae4e-0466-4a77-8862-0d634371a049", "", "adminVersion_0001", new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9317) },
                    { "d8b8ec79-cd6e-433e-8de6-7b7af589af7c", new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9206), new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9215), "test001@gmail.com", "test", false, "account", "nSUQ/133didCpNJLsvcLvQ==", "test001@gmail.com", "527428c3-5f67-42bc-a573-f11471706589", "", "testVersion_0001", new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9216) }
                });
        }
    }
}
