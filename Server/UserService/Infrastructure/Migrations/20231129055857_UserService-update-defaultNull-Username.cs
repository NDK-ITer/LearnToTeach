using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserServiceupdatedefaultNullUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "11750602-8c16-40d1-8991-4fefc0858b40");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6c397b90-c8e4-40db-8e49-49ab3f0bda64");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "NormalizeName" },
                values: new object[,]
                {
                    { "849a0fed-3ecf-4655-bc31-6c65e166395e", "", "ADMIN", "Admin" },
                    { "cd2676e0-0861-472b-be14-32de8e39e01e", "", "USER", "User" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "193ba283-bf34-40ad-a3be-10b1780cba0e",
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 29, 12, 58, 57, 424, DateTimeKind.Local).AddTicks(5483), new DateTime(2023, 11, 29, 12, 58, 57, 424, DateTimeKind.Local).AddTicks(5494), "cd2676e0-0861-472b-be14-32de8e39e01e", "3A3AB8676FE9D10C9E9E3B4E6C8505E74FB8F3940AE9223C0E1536EBA02E7CB2E185C108A503E76734A98E55D03FE364415C01391EE323C6C718354BCF1C74CE", new DateTime(2023, 11, 29, 12, 58, 57, 424, DateTimeKind.Local).AddTicks(5547) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2c75293b-f8e5-4862-9b13-5894a64895cd",
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 29, 12, 58, 57, 424, DateTimeKind.Local).AddTicks(5696), new DateTime(2023, 11, 29, 12, 58, 57, 424, DateTimeKind.Local).AddTicks(5697), "849a0fed-3ecf-4655-bc31-6c65e166395e", "E8EB138CEC24407BC3917AAFB050CA0C5B2547D29458457FE378AA86DD709B5F12CFE9FB4202A38FE1651A0BC08583BC3C6D757C42E527C1DC43CE18219359D4", new DateTime(2023, 11, 29, 12, 58, 57, 424, DateTimeKind.Local).AddTicks(5702) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "849a0fed-3ecf-4655-bc31-6c65e166395e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd2676e0-0861-472b-be14-32de8e39e01e");

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
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6172), new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6183), "11750602-8c16-40d1-8991-4fefc0858b40", "5F5A5B09CAC68E3090D3DDE024B40DAEC657E332A182C4020407C2CA0CA1E3D1C4374853223A9E325D10C7CD09AE600EECE97B34CB451D4D1BA95BED98A5E47D", new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6238) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2c75293b-f8e5-4862-9b13-5894a64895cd",
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6328), new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6328), "6c397b90-c8e4-40db-8e49-49ab3f0bda64", "20BEEC96FCFF4507D35B65D18952FEF9913531418A3EBF0B68A2128FB2864697EED308F3A4F0AACDDA59A1907FA0D53065CC658D61C1254C453A5745622B1FA1", new DateTime(2023, 11, 16, 10, 43, 11, 675, DateTimeKind.Local).AddTicks(6334) });
        }
    }
}
