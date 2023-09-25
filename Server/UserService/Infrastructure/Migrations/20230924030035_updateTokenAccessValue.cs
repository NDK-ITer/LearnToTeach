using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTokenAccessValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "5ea8f252-bddc-4331-943e-d857aa72f168", "", "USER", "User" },
                    { "7f171b2d-a876-4c10-b2ad-2ebfe7549b1a", "", "ADMIN", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "IsVerified", "LastName", "PasswordHash", "PresentEmail", "RoleId", "TokenAccess", "UserName", "VerifiedDate" },
                values: new object[,]
                {
                    { "08663590-4283-4c15-a453-fca6b8c8b7d1", new DateTime(2023, 9, 24, 10, 0, 35, 100, DateTimeKind.Local).AddTicks(6427), new DateTime(2023, 9, 24, 10, 0, 35, 100, DateTimeKind.Local).AddTicks(6439), "test001@gmail.com", "test", false, true, "account", "nSUQ/133didCpNJLsvcLvQ==", "test001@gmail.com", "5ea8f252-bddc-4331-943e-d857aa72f168", "D3F404BB3713D7EEB4A4EE37D70451FA058B8773E27FCF1C746D63971873C3620501DA1B42763183DC39F17117063789336BF507D50E29B38902D63444241DEA", "testVersion_0001", new DateTime(2023, 9, 24, 10, 0, 35, 100, DateTimeKind.Local).AddTicks(6520) },
                    { "1161df41-7148-4ecf-9497-40b30e4759c6", new DateTime(2023, 9, 24, 10, 0, 35, 100, DateTimeKind.Local).AddTicks(6622), new DateTime(2023, 9, 24, 10, 0, 35, 100, DateTimeKind.Local).AddTicks(6623), "admin001@gmail.com", "Admin", false, true, "account", "VWBU8/+H4em26o8A92n+Tg==", "admin001@gmail.com", "7f171b2d-a876-4c10-b2ad-2ebfe7549b1a", "72838E661AD2BBC3AC9D91383A5C893C8C4A107291B12BEAEDC8ACCE2ACDDDC375F4A32A6906BA3751A205D2D16DFB720C90347AB768275BE742F8148DABD1A3", "adminVersion_0001", new DateTime(2023, 9, 24, 10, 0, 35, 100, DateTimeKind.Local).AddTicks(6628) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "08663590-4283-4c15-a453-fca6b8c8b7d1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "1161df41-7148-4ecf-9497-40b30e4759c6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5ea8f252-bddc-4331-943e-d857aa72f168");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7f171b2d-a876-4c10-b2ad-2ebfe7549b1a");

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
    }
}
