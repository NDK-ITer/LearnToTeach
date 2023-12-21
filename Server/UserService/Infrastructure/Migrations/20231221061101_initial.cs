using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "33121411-067a-4bde-9a60-08dc24a6df27", "", "USER", "User" },
                    { "9a78a829-50d1-49e1-90d8-cdeff4e66dcb", "", "ADMIN", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "193ba283-bf34-40ad-a3be-10b1780cba0e",
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 12, 21, 13, 11, 1, 544, DateTimeKind.Local).AddTicks(8532), new DateTime(2023, 12, 21, 13, 11, 1, 544, DateTimeKind.Local).AddTicks(8543), "33121411-067a-4bde-9a60-08dc24a6df27", "25017E180EA565F346D17BA12F9AC8FD3F240A899BB5C17A795C0405308C32138D61495F0C68E85588C6688C49699B31936DF2E0E5BBC3E1ED7D0C1FCD66B673", new DateTime(2023, 12, 21, 13, 11, 1, 544, DateTimeKind.Local).AddTicks(8596) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: "2c75293b-f8e5-4862-9b13-5894a64895cd",
                columns: new[] { "Birthday", "CreatedDate", "RoleId", "TokenAccess", "VerifiedDate" },
                values: new object[] { new DateTime(2023, 12, 21, 13, 11, 1, 544, DateTimeKind.Local).AddTicks(8722), new DateTime(2023, 12, 21, 13, 11, 1, 544, DateTimeKind.Local).AddTicks(8723), "9a78a829-50d1-49e1-90d8-cdeff4e66dcb", "4EC4E1E81F31E1C09252080BFA6A8AF9FD38E8C3B16F673380A990B81AEC1D7C9ACB2B37DB8BA3DBFF76D9144AC22B90F470AF4123451D7AA95F410849E0ED22", new DateTime(2023, 12, 21, 13, 11, 1, 544, DateTimeKind.Local).AddTicks(8727) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "33121411-067a-4bde-9a60-08dc24a6df27");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9a78a829-50d1-49e1-90d8-cdeff4e66dcb");

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
    }
}
