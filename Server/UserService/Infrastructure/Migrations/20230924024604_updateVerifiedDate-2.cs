using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateVerifiedDate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "7b154a7c-f94a-429c-b623-563ff5762a71");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "a04ec7e0-f458-4830-bf25-73c3fb2f3b9e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "785c24a7-efed-4bb0-aedf-cf0be63d311a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b5d0cb25-688c-4eda-a7fd-9f2c71d12fd3");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VerifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "VerifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "785c24a7-efed-4bb0-aedf-cf0be63d311a", "", "USER", "User" },
                    { "b5d0cb25-688c-4eda-a7fd-9f2c71d12fd3", "", "ADMIN", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "LastName", "PasswordHash", "PresentEmail", "RoleId", "TokenAccess", "UserName", "VerifiedDate" },
                values: new object[,]
                {
                    { "7b154a7c-f94a-429c-b623-563ff5762a71", new DateTime(2023, 9, 24, 9, 43, 16, 357, DateTimeKind.Local).AddTicks(8696), new DateTime(2023, 9, 24, 9, 43, 16, 357, DateTimeKind.Local).AddTicks(8709), "test001@gmail.com", "test", false, "account", "nSUQ/133didCpNJLsvcLvQ==", "test001@gmail.com", "785c24a7-efed-4bb0-aedf-cf0be63d311a", "", "testVersion_0001", new DateTime(2023, 9, 24, 9, 43, 16, 357, DateTimeKind.Local).AddTicks(8710) },
                    { "a04ec7e0-f458-4830-bf25-73c3fb2f3b9e", new DateTime(2023, 9, 24, 9, 43, 16, 357, DateTimeKind.Local).AddTicks(8806), new DateTime(2023, 9, 24, 9, 43, 16, 357, DateTimeKind.Local).AddTicks(8807), "admin001@gmail.com", "Admin", false, "account", "VWBU8/+H4em26o8A92n+Tg==", "admin001@gmail.com", "b5d0cb25-688c-4eda-a7fd-9f2c71d12fd3", "", "adminVersion_0001", new DateTime(2023, 9, 24, 9, 43, 16, 357, DateTimeKind.Local).AddTicks(8808) }
                });
        }
    }
}
