using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateNameMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "11ebaeae-2995-4ca5-b156-481e6751981a", "193ba283-bf34-40ad-a3be-10b1780cba0e" });

            migrationBuilder.DeleteData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "d0b069eb-7be8-4482-9f15-5515227644d5", "2c75293b-f8e5-4862-9b13-5894a64895cd" });

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "11ebaeae-2995-4ca5-b156-481e6751981a");

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "d0b069eb-7be8-4482-9f15-5515227644d5");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 3, 13, 50, 46, 361, DateTimeKind.Local).AddTicks(7606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 3, 13, 46, 23, 708, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "AvatarUserHost", "CreateDate", "Description", "IdUserHost", "IsPrivate", "KeyHash", "Name", "NameUserHost" },
                values: new object[,]
                {
                    { "0a006921-b4a4-40de-a1e6-9497daf09a2f", null, new DateTime(2023, 11, 3, 13, 50, 46, 362, DateTimeKind.Local).AddTicks(5277), null, "2c75293b-f8e5-4862-9b13-5894a64895cd", false, null, "Class_2", null },
                    { "ee546ce7-842a-4dee-86d0-0db1ff3b64b4", null, new DateTime(2023, 11, 3, 13, 50, 46, 362, DateTimeKind.Local).AddTicks(5101), null, "193ba283-bf34-40ad-a3be-10b1780cba0e", true, "cA4FigUKj7deRjen/4NWmw==", "Class_1", null }
                });

            migrationBuilder.InsertData(
                table: "MemberClassroom",
                columns: new[] { "IdClass", "IdUser", "Avatar", "Description", "Name", "Role" },
                values: new object[,]
                {
                    { "0a006921-b4a4-40de-a1e6-9497daf09a2f", "193ba283-bf34-40ad-a3be-10b1780cba0e", "", "", "test account", "" },
                    { "ee546ce7-842a-4dee-86d0-0db1ff3b64b4", "2c75293b-f8e5-4862-9b13-5894a64895cd", "", "", "Admin account", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "0a006921-b4a4-40de-a1e6-9497daf09a2f", "193ba283-bf34-40ad-a3be-10b1780cba0e" });

            migrationBuilder.DeleteData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "ee546ce7-842a-4dee-86d0-0db1ff3b64b4", "2c75293b-f8e5-4862-9b13-5894a64895cd" });

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "0a006921-b4a4-40de-a1e6-9497daf09a2f");

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "ee546ce7-842a-4dee-86d0-0db1ff3b64b4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 3, 13, 46, 23, 708, DateTimeKind.Local).AddTicks(1688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 3, 13, 50, 46, 361, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "AvatarUserHost", "CreateDate", "Description", "IdUserHost", "IsPrivate", "KeyHash", "Name", "NameUserHost" },
                values: new object[,]
                {
                    { "11ebaeae-2995-4ca5-b156-481e6751981a", null, new DateTime(2023, 11, 3, 13, 46, 23, 708, DateTimeKind.Local).AddTicks(9145), null, "2c75293b-f8e5-4862-9b13-5894a64895cd", false, null, "Class_2", null },
                    { "d0b069eb-7be8-4482-9f15-5515227644d5", null, new DateTime(2023, 11, 3, 13, 46, 23, 708, DateTimeKind.Local).AddTicks(8954), null, "193ba283-bf34-40ad-a3be-10b1780cba0e", true, "cA4FigUKj7deRjen/4NWmw==", "Class_1", null }
                });

            migrationBuilder.InsertData(
                table: "MemberClassroom",
                columns: new[] { "IdClass", "IdUser", "Avatar", "Description", "Name", "Role" },
                values: new object[,]
                {
                    { "11ebaeae-2995-4ca5-b156-481e6751981a", "193ba283-bf34-40ad-a3be-10b1780cba0e", "", "", "", "" },
                    { "d0b069eb-7be8-4482-9f15-5515227644d5", "2c75293b-f8e5-4862-9b13-5894a64895cd", "", "", "", "" }
                });
        }
    }
}
