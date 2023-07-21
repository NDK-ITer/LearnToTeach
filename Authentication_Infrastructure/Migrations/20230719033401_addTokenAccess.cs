using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTokenAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "3832d446-295c-42ff-a9c1-366aa79afd5c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "52a2f36c-9a84-4a31-ba41-3b10b3e95b6d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "20198e81-3965-44ee-9029-d8d8cce8668e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5c011058-f02a-4a2b-b81a-143551fb3bb5");

            migrationBuilder.AddColumn<string>(
                name: "TokenAccess",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "262219bd-1183-430e-95fe-59feb43f510c", "", "ADMIN", "Admin" },
                    { "f79a3acd-517e-4a18-9452-59995527225d", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "LastName", "PasswordHash", "PresentEmail", "RoleId", "TokenAccess", "UserName" },
                values: new object[,]
                {
                    { "6adf989c-1f4a-4398-8294-19fc76cb6e2a", new DateTime(2023, 7, 19, 10, 34, 1, 173, DateTimeKind.Local).AddTicks(3334), new DateTime(2023, 7, 19, 10, 34, 1, 173, DateTimeKind.Local).AddTicks(3349), "test001@gmail.com", "test", false, "account", "nSUQ/133didCpNJLsvcLvQ==", "test001@gmail.com", "f79a3acd-517e-4a18-9452-59995527225d", "", "testVersion_0001" },
                    { "c01b13d6-84c9-44b9-ad22-9fd24dafe4dd", new DateTime(2023, 7, 19, 10, 34, 1, 173, DateTimeKind.Local).AddTicks(3447), new DateTime(2023, 7, 19, 10, 34, 1, 173, DateTimeKind.Local).AddTicks(3448), "admin001@gmail.com", "Admin", false, "account", "VWBU8/+H4em26o8A92n+Tg==", "admin001@gmail.com", "262219bd-1183-430e-95fe-59feb43f510c", "", "adminVersion_0001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "6adf989c-1f4a-4398-8294-19fc76cb6e2a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: "c01b13d6-84c9-44b9-ad22-9fd24dafe4dd");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "262219bd-1183-430e-95fe-59feb43f510c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f79a3acd-517e-4a18-9452-59995527225d");

            migrationBuilder.DropColumn(
                name: "TokenAccess",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NomalizeName" },
                values: new object[,]
                {
                    { "20198e81-3965-44ee-9029-d8d8cce8668e", "", "ADMIN", "Admin" },
                    { "5c011058-f02a-4a2b-b81a-143551fb3bb5", "", "USER", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Birthday", "CreatedDate", "FirstEmail", "FirstName", "IsLock", "LastName", "PasswordHash", "PresentEmail", "RoleId", "UserName" },
                values: new object[,]
                {
                    { "3832d446-295c-42ff-a9c1-366aa79afd5c", new DateTime(2023, 7, 18, 14, 34, 13, 464, DateTimeKind.Local).AddTicks(5534), new DateTime(2023, 7, 18, 14, 34, 13, 464, DateTimeKind.Local).AddTicks(5546), "test001@gmail.com", "test", false, "account", "nSUQ/133didCpNJLsvcLvQ==", "test001@gmail.com", "5c011058-f02a-4a2b-b81a-143551fb3bb5", "testVersion_0001" },
                    { "52a2f36c-9a84-4a31-ba41-3b10b3e95b6d", new DateTime(2023, 7, 18, 14, 34, 13, 464, DateTimeKind.Local).AddTicks(5639), new DateTime(2023, 7, 18, 14, 34, 13, 464, DateTimeKind.Local).AddTicks(5639), "admin001@gmail.com", "Admin", false, "account", "VWBU8/+H4em26o8A92n+Tg==", "admin001@gmail.com", "20198e81-3965-44ee-9029-d8d8cce8668e", "adminVersion_0001" }
                });
        }
    }
}
