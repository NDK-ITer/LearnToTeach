using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateVerifiedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "8a931330-dfa6-4420-a4c7-481fb1a70bbf");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "9d853125-0a15-40ee-bbc1-ee25fbdbacc1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "414ccb36-d5fe-4e42-937b-ccfc133bcae2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6cdaf2ef-dfe5-48db-bb63-94b6d46ebc1e");

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "VerifiedDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "414ccb36-d5fe-4e42-937b-ccfc133bcae2", "", "ADMIN", "Admin" },
                    { "6cdaf2ef-dfe5-48db-bb63-94b6d46ebc1e", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "LastName", "PasswordHash", "PresentEmail", "RoleId", "TokenAccess", "UserName" },
                values: new object[,]
                {
                    { "8a931330-dfa6-4420-a4c7-481fb1a70bbf", new DateTime(2023, 7, 21, 10, 18, 49, 436, DateTimeKind.Local).AddTicks(9653), new DateTime(2023, 7, 21, 10, 18, 49, 436, DateTimeKind.Local).AddTicks(9654), "admin001@gmail.com", "Admin", false, "account", "VWBU8/+H4em26o8A92n+Tg==", "admin001@gmail.com", "414ccb36-d5fe-4e42-937b-ccfc133bcae2", "", "adminVersion_0001" },
                    { "9d853125-0a15-40ee-bbc1-ee25fbdbacc1", new DateTime(2023, 7, 21, 10, 18, 49, 436, DateTimeKind.Local).AddTicks(9532), new DateTime(2023, 7, 21, 10, 18, 49, 436, DateTimeKind.Local).AddTicks(9544), "test001@gmail.com", "test", false, "account", "nSUQ/133didCpNJLsvcLvQ==", "test001@gmail.com", "6cdaf2ef-dfe5-48db-bb63-94b6d46ebc1e", "", "testVersion_0001" }
                });
        }
    }
}
