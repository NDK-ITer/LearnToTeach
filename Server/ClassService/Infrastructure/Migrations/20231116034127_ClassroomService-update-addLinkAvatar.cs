using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceupdateaddLinkAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkAvatar",
                table: "MemberClassroom",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 16, 10, 41, 27, 759, DateTimeKind.Local).AddTicks(2635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 6, 9, 25, 29, 912, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUserHost",
                table: "Classrooms",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarClassroom",
                table: "Classrooms",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkAvatar",
                table: "Classrooms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "02c47002-cc29-4b66-82bd-a86b7e3c6d5e",
                columns: new[] { "AvatarClassroom", "AvatarUserHost", "CreateDate", "LinkAvatar" },
                values: new object[] { "", "", new DateTime(2023, 11, 16, 10, 41, 27, 760, DateTimeKind.Local).AddTicks(63), "" });

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "d0186509-69d2-4a76-a0d1-69c5916c0b02",
                columns: new[] { "AvatarClassroom", "AvatarUserHost", "CreateDate", "LinkAvatar" },
                values: new object[] { "", "", new DateTime(2023, 11, 16, 10, 41, 27, 759, DateTimeKind.Local).AddTicks(9881), "" });

            migrationBuilder.UpdateData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "02c47002-cc29-4b66-82bd-a86b7e3c6d5e", "193ba283-bf34-40ad-a3be-10b1780cba0e" },
                columns: new[] { "LinkAvatar", "Role" },
                values: new object[] { "", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "d0186509-69d2-4a76-a0d1-69c5916c0b02", "2c75293b-f8e5-4862-9b13-5894a64895cd" },
                columns: new[] { "LinkAvatar", "Role" },
                values: new object[] { "", "MEMBER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkAvatar",
                table: "MemberClassroom");

            migrationBuilder.DropColumn(
                name: "AvatarClassroom",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "LinkAvatar",
                table: "Classrooms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 6, 9, 25, 29, 912, DateTimeKind.Local).AddTicks(4929),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 16, 10, 41, 27, 759, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUserHost",
                table: "Classrooms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "02c47002-cc29-4b66-82bd-a86b7e3c6d5e",
                columns: new[] { "AvatarUserHost", "CreateDate" },
                values: new object[] { null, new DateTime(2023, 11, 6, 9, 25, 29, 913, DateTimeKind.Local).AddTicks(3514) });

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "d0186509-69d2-4a76-a0d1-69c5916c0b02",
                columns: new[] { "AvatarUserHost", "CreateDate" },
                values: new object[] { null, new DateTime(2023, 11, 6, 9, 25, 29, 913, DateTimeKind.Local).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "02c47002-cc29-4b66-82bd-a86b7e3c6d5e", "193ba283-bf34-40ad-a3be-10b1780cba0e" },
                column: "Role",
                value: "");

            migrationBuilder.UpdateData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "d0186509-69d2-4a76-a0d1-69c5916c0b02", "2c75293b-f8e5-4862-9b13-5894a64895cd" },
                column: "Role",
                value: "");
        }
    }
}
