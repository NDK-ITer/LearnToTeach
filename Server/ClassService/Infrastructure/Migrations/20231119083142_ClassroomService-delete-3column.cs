using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServicedelete3column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUserHost",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "IdUserHost",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "NameUserHost",
                table: "Classrooms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 15, 31, 42, 460, DateTimeKind.Local).AddTicks(2144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 14, 21, 23, 841, DateTimeKind.Local).AddTicks(9002));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 14, 21, 23, 841, DateTimeKind.Local).AddTicks(9002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 15, 31, 42, 460, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.AddColumn<string>(
                name: "AvatarUserHost",
                table: "Classrooms",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserHost",
                table: "Classrooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameUserHost",
                table: "Classrooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
