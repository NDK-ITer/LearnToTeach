using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceaddExcerciseandAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 870, DateTimeKind.Local).AddTicks(1025),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 15, 39, 21, 755, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    IdExercise = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 872, DateTimeKind.Local).AddTicks(3644)),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LinkFile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdClassroom = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.IdExercise);
                    table.ForeignKey(
                        name: "FK_Exercise_Classrooms_IdClassroom",
                        column: x => x.IdClassroom,
                        principalTable: "Classrooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    IdAnswer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMember = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    IdExercise = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateAnswer = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 872, DateTimeKind.Local).AddTicks(6791)),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkFile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.IdAnswer);
                    table.ForeignKey(
                        name: "FK_Answer_Exercise_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "IdExercise");
                    table.ForeignKey(
                        name: "FK_Answer_Member_IdMember",
                        column: x => x.IdMember,
                        principalTable: "Member",
                        principalColumn: "IdMember");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_IdExercise",
                table: "Answer",
                column: "IdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_IdMember",
                table: "Answer",
                column: "IdMember");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdClassroom",
                table: "Exercise",
                column: "IdClassroom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 15, 39, 21, 755, DateTimeKind.Local).AddTicks(7307),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 870, DateTimeKind.Local).AddTicks(1025));
        }
    }
}
