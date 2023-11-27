using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceaddtablenotify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(7881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 612, DateTimeKind.Local).AddTicks(4007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 821, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(9293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.CreateTable(
                name: "NotifyClassroom",
                columns: table => new
                {
                    IdNotify = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 616, DateTimeKind.Local).AddTicks(1651)),
                    NameNotify = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IdClassroom = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyClassroom", x => x.IdNotify);
                    table.ForeignKey(
                        name: "FK_NotifyClassroom_Classrooms_IdClassroom",
                        column: x => x.IdClassroom,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotifyClassroom_IdClassroom",
                table: "NotifyClassroom",
                column: "IdClassroom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotifyClassroom");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(5078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 821, DateTimeKind.Local).AddTicks(3812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 612, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(6406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 27, 14, 41, 47, 615, DateTimeKind.Local).AddTicks(9293));
        }
    }
}
