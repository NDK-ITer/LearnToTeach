using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceupdateColumnUpdateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(9855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(8567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(5489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 315, DateTimeKind.Local).AddTicks(6767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 302, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(6978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(6907));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Exercise");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(9570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(8480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(5641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 302, DateTimeKind.Local).AddTicks(2164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 315, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 24, 0, 305, DateTimeKind.Local).AddTicks(6907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(6978));
        }
    }
}
