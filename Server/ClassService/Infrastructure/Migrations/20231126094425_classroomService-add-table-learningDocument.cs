using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class classroomServiceaddtablelearningDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(5078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(6517));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 821, DateTimeKind.Local).AddTicks(3812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 852, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(6406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.CreateTable(
                name: "LearningDocument",
                columns: table => new
                {
                    NameFile = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LinkFile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdClassroom = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningDocument", x => x.NameFile);
                    table.ForeignKey(
                        name: "FK_LearningDocument_Classrooms_IdClassroom",
                        column: x => x.IdClassroom,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningDocument_IdClassroom",
                table: "LearningDocument",
                column: "IdClassroom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningDocument");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(6517),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 852, DateTimeKind.Local).AddTicks(6658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 821, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 25, 15, 21, 33, 855, DateTimeKind.Local).AddTicks(7781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 26, 16, 44, 25, 824, DateTimeKind.Local).AddTicks(6406));
        }
    }
}
