using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "2dd4da4a-ef7b-45dc-803e-8d28838847ca", "", "ADMIN", "Admin" },
                    { "9af1df9b-4423-45f0-be02-874f4943a9d3", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "IsVerified", "LastName", "PasswordHash", "PhoneNumber", "PresentEmail", "RoleId", "TokenAccess", "UserName", "VerifiedDate" },
                values: new object[,]
                {
                    { "193ba283-bf34-40ad-a3be-10b1780cba0e", new DateTime(2023, 9, 26, 9, 11, 33, 830, DateTimeKind.Local).AddTicks(6264), new DateTime(2023, 9, 26, 9, 11, 33, 830, DateTimeKind.Local).AddTicks(6276), "test001@gmail.com", "test", false, true, "account", "nSUQ/133didCpNJLsvcLvQ==", "0123456789", "test001@gmail.com", "9af1df9b-4423-45f0-be02-874f4943a9d3", "F3BBC5126D578B41D3C49A0E91E1518B3C0CB18274DC3ABB35A3947A09FF42BBE176868F90C5609D9D92DB76319C5846B569A27F209B733125AA132A59205D68", "testVersion_0001", new DateTime(2023, 9, 26, 9, 11, 33, 830, DateTimeKind.Local).AddTicks(6328) },
                    { "2c75293b-f8e5-4862-9b13-5894a64895cd", new DateTime(2023, 9, 26, 9, 11, 33, 830, DateTimeKind.Local).AddTicks(6416), new DateTime(2023, 9, 26, 9, 11, 33, 830, DateTimeKind.Local).AddTicks(6417), "admin001@gmail.com", "Admin", false, true, "account", "VWBU8/+H4em26o8A92n+Tg==", "0123456789", "admin001@gmail.com", "2dd4da4a-ef7b-45dc-803e-8d28838847ca", "506D7E16F7B68C4801F96446B44825C5711A87A007063BC1E58008BD64BB76A4C3FD6CF5F5EF81A3367DF1ABA417C4E10AF84F9C1786B5468769805944EE08FA", "adminVersion_0001", new DateTime(2023, 9, 26, 9, 11, 33, 830, DateTimeKind.Local).AddTicks(6422) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "193ba283-bf34-40ad-a3be-10b1780cba0e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2c75293b-f8e5-4862-9b13-5894a64895cd");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2dd4da4a-ef7b-45dc-803e-8d28838847ca");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9af1df9b-4423-45f0-be02-874f4943a9d3");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

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
    }
}
