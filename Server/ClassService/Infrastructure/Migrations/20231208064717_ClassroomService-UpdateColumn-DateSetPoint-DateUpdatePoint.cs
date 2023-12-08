using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceUpdateColumnDateSetPointDateUpdatePoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(9273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(7897),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(4691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 123, DateTimeKind.Local).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 315, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(6277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSetPoint",
                table: "Answer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdatePoint",
                table: "Answer",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSetPoint",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "DateUpdatePoint",
                table: "Answer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(9855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(8567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(5489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 315, DateTimeKind.Local).AddTicks(6767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 123, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(6978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(6277));
        }
    }
}
