using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServicetableLearningDocumentaddColumnUploadDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(8159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 616, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(3946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 172, DateTimeKind.Local).AddTicks(9894),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 612, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(5229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(9293));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "LearningDocument");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 616, DateTimeKind.Local).AddTicks(1651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(7881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(3946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 612, DateTimeKind.Local).AddTicks(4007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 172, DateTimeKind.Local).AddTicks(9894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(9293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 9, 9, 50, 176, DateTimeKind.Local).AddTicks(5229));
        }
    }
}
