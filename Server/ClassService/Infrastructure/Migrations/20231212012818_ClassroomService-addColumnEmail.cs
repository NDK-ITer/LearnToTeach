using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceaddColumnEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 900, DateTimeKind.Local).AddTicks(2724),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Member",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 900, DateTimeKind.Local).AddTicks(1688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 899, DateTimeKind.Local).AddTicks(9021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 896, DateTimeKind.Local).AddTicks(6159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 123, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 900, DateTimeKind.Local).AddTicks(282),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(6277));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Member");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "NotifyClassroom",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(9273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 900, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadDate",
                table: "LearningDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(7897),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 900, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(4691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 899, DateTimeKind.Local).AddTicks(9021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 123, DateTimeKind.Local).AddTicks(4972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 896, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 13, 47, 17, 127, DateTimeKind.Local).AddTicks(6277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 12, 8, 28, 18, 900, DateTimeKind.Local).AddTicks(282));
        }
    }
}
