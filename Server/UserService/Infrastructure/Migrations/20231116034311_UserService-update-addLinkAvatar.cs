using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserServiceupdateaddLinkAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3bfa0033-ec25-4271-9ca3-7f158bf5dab2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fd62b292-ec16-4c4b-9e83-907a3e579041");

            migrationBuilder.AddColumn<string>(
                name: "LinkAvatar",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "ClassroomInfor",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkAvatar",
                table: "ClassroomInfor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ClassroomInfor",
                keyColumns: new[] { "IdClassroom", "IdUser" },
                keyValues: new object[] { "ee546ce7-842a-4dee-86d0-0db1ff3b64b4", "193ba283-bf34-40ad-a3be-10b1780cba0e" },
                columns: new[] { "Avatar", "LinkAvatar" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ClassroomInfor",
                keyColumns: new[] { "IdClassroom", "IdUser" },
                keyValues: new object[] { "0a006921-b4a4-40de-a1e6-9497daf09a2f", "2c75293b-f8e5-4862-9b13-5894a64895cd" },
                columns: new[] { "Avatar", "LinkAvatar" },
                values: new object[] { "", "" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NormalizeName" },
                values: new object[,]
                {
                    { "11750602-8c16-40d1-8991-4fefc0858b40", "", "USER", "User" },
                    { "6c397b90-c8e4-40db-8e49-49ab3f0bda64", "", "ADMIN", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "193ba283-bf34-40ad-a3be-10b1780cba0e",
                columns: new[] { "Birthday", "CreatedDate", "LinkAvatar", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6172), new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6183), "", "11750602-8c16-40d1-8991-4fefc0858b40", "5F5A5B09CAC68E3090D3DDE024B40DAEC657E332A182C4020407C2CA0CA1E3D1C4374853223A9E325D10C7CD09AE600EECE97B34CB451D4D1BA95BED98A5E47D", new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6238) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2c75293b-f8e5-4862-9b13-5894a64895cd",
                columns: new[] { "Birthday", "CreatedDate", "LinkAvatar", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6328), new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6328), "", "6c397b90-c8e4-40db-8e49-49ab3f0bda64", "20BEEC96FCFF4507D35B65D18952FEF9913531418A3EBF0B68A2128FB2864697EED308F3A4F0AACDDA59A1907FA0D53065CC658D61C1254C453A5745622B1FA1", new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6334) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "11750602-8c16-40d1-8991-4fefc0858b40");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6c397b90-c8e4-40db-8e49-49ab3f0bda64");

            migrationBuilder.DropColumn(
                name: "LinkAvatar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "ClassroomInfor");

            migrationBuilder.DropColumn(
                name: "LinkAvatar",
                table: "ClassroomInfor");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NormalizeName" },
                values: new object[,]
                {
                    { "3bfa0033-ec25-4271-9ca3-7f158bf5dab2", "", "ADMIN", "Admin" },
                    { "fd62b292-ec16-4c4b-9e83-907a3e579041", "", "USER", "User" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "193ba283-bf34-40ad-a3be-10b1780cba0e",
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7063), new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7075), "fd62b292-ec16-4c4b-9e83-907a3e579041", "4C1745F0002B41D8CBFC286958F1B825F09F2CDE8A1359DC43C43401532E0EA09E76BBA37D49E913BC6590F197E2A2CB42E2EDFF95F8037F41220E5267737150", new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2c75293b-f8e5-4862-9b13-5894a64895cd",
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7223), new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7223), "3bfa0033-ec25-4271-9ca3-7f158bf5dab2", "62BAEE704AD866A50E5AFCBEBCB040BBF73D19657FF692EAB3B5C56D18A94C1C3D4A810A062F84AA21DC3A2631DD289925888731DD6E198D894762D3DCEEF424", new DateTime(2023, 11, 6, 9, 24, 38, 137, DateTimeKind.Local).AddTicks(7226) });
        }
    }
}
