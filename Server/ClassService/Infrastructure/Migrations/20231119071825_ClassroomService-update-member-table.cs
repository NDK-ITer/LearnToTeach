using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceupdatemembertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "02c47002-cc29-4b66-82bd-a86b7e3c6d5e", "193ba283-bf34-40ad-a3be-10b1780cba0e" });

            migrationBuilder.DeleteData(
                table: "MemberClassroom",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "d0186509-69d2-4a76-a0d1-69c5916c0b02", "2c75293b-f8e5-4862-9b13-5894a64895cd" });

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "02c47002-cc29-4b66-82bd-a86b7e3c6d5e");

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "d0186509-69d2-4a76-a0d1-69c5916c0b02");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MemberClassroom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkAvatar",
                table: "MemberClassroom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "MemberClassroom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 14, 18, 25, 545, DateTimeKind.Local).AddTicks(2885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 16, 10, 41, 27, 759, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LinkAvatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.IdUser);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MemberClassroom_Member_IdUser",
                table: "MemberClassroom",
                column: "IdUser",
                principalTable: "Member",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberClassroom_Member_IdUser",
                table: "MemberClassroom");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MemberClassroom",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LinkAvatar",
                table: "MemberClassroom",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "MemberClassroom",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 16, 10, 41, 27, 759, DateTimeKind.Local).AddTicks(2635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 14, 18, 25, 545, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "AvatarClassroom", "AvatarUserHost", "CreateDate", "Description", "IdUserHost", "IsPrivate", "KeyHash", "LinkAvatar", "Name", "NameUserHost" },
                values: new object[,]
                {
                    { "02c47002-cc29-4b66-82bd-a86b7e3c6d5e", "", "", new DateTime(2023, 11, 16, 10, 41, 27, 760, DateTimeKind.Local).AddTicks(63), null, "2c75293b-f8e5-4862-9b13-5894a64895cd", false, null, "", "Class_2", null },
                    { "d0186509-69d2-4a76-a0d1-69c5916c0b02", "", "", new DateTime(2023, 11, 16, 10, 41, 27, 759, DateTimeKind.Local).AddTicks(9881), null, "193ba283-bf34-40ad-a3be-10b1780cba0e", true, "cA4FigUKj7deRjen/4NWmw==", "", "Class_1", null }
                });

            migrationBuilder.InsertData(
                table: "MemberClassroom",
                columns: new[] { "IdClass", "IdUser", "Avatar", "Description", "LinkAvatar", "Name", "Role" },
                values: new object[,]
                {
                    { "02c47002-cc29-4b66-82bd-a86b7e3c6d5e", "193ba283-bf34-40ad-a3be-10b1780cba0e", "", "", "", "test account", "MEMBER" },
                    { "d0186509-69d2-4a76-a0d1-69c5916c0b02", "2c75293b-f8e5-4862-9b13-5894a64895cd", "", "", "", "Admin account", "MEMBER" }
                });
        }
    }
}
