using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceaddcolumnpoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(6517),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 852, DateTimeKind.Local).AddTicks(6658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 951, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(7781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.AddColumn<float>(
                name: "Point",
                table: "Answer",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Answer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(1090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(6517));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 951, DateTimeKind.Local).AddTicks(2928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 852, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 22, 32, 42, 954, DateTimeKind.Local).AddTicks(2374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(7781));
        }
    }
}
