using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceupdateAnswerFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(1090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 21, 20, 1, 11, 536, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 951, DateTimeKind.Local).AddTicks(2928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 21, 20, 1, 11, 533, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(2374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 21, 20, 1, 11, 536, DateTimeKind.Local).AddTicks(5803));

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Answer",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Answer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 21, 20, 1, 11, 536, DateTimeKind.Local).AddTicks(4364),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 21, 20, 1, 11, 533, DateTimeKind.Local).AddTicks(2818),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 951, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 21, 20, 1, 11, 536, DateTimeKind.Local).AddTicks(5803),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(2374));
        }
    }
}
