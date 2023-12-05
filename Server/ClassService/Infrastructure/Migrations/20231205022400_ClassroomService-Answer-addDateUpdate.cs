using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceAnsweraddDateUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(9570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(8480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(5641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(3946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 302, DateTimeKind.Local).AddTicks(2164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 172, DateTimeKind.Local).AddTicks(9894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(6907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdateAnswer",
                table: "Answer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(8159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(6816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(3946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 172, DateTimeKind.Local).AddTicks(9894),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 302, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(5229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(6907));
        }
    }
}
