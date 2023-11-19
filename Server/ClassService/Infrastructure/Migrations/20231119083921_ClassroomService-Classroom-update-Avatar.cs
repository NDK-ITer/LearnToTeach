using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceClassroomupdateAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarClassroom",
                table: "Classrooms",
                newName: "Avatar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 15, 39, 21, 755, DateTimeKind.Local).AddTicks(7307),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 15, 33, 35, 713, DateTimeKind.Local).AddTicks(5232));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "Classrooms",
                newName: "AvatarClassroom");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 15, 33, 35, 713, DateTimeKind.Local).AddTicks(5232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 15, 39, 21, 755, DateTimeKind.Local).AddTicks(7307));
        }
    }
}
