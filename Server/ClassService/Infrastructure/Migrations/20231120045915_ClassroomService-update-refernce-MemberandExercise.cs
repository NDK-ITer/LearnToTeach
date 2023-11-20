using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceupdaterefernceMemberandExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Exercise_IdExercise",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Member_IdMember",
                table: "Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_IdExercise",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "IdAnswer",
                table: "Answer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 11, 59, 15, 691, DateTimeKind.Local).AddTicks(9643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 872, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 11, 59, 15, 689, DateTimeKind.Local).AddTicks(772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 870, DateTimeKind.Local).AddTicks(1025));

            migrationBuilder.AlterColumn<string>(
                name: "IdMember",
                table: "Answer",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdExercise",
                table: "Answer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 11, 59, 15, 692, DateTimeKind.Local).AddTicks(985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 872, DateTimeKind.Local).AddTicks(6791));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                columns: new[] { "IdExercise", "IdMember" });

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Exercise_IdExercise",
                table: "Answer",
                column: "IdExercise",
                principalTable: "Exercise",
                principalColumn: "IdExercise",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Member_IdMember",
                table: "Answer",
                column: "IdMember",
                principalTable: "Member",
                principalColumn: "IdMember",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Exercise_IdExercise",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Member_IdMember",
                table: "Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Exercise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 872, DateTimeKind.Local).AddTicks(3644),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 20, 11, 59, 15, 691, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 870, DateTimeKind.Local).AddTicks(1025),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 20, 11, 59, 15, 689, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAnswer",
                table: "Answer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 11, 25, 32, 872, DateTimeKind.Local).AddTicks(6791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 20, 11, 59, 15, 692, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.AlterColumn<string>(
                name: "IdMember",
                table: "Answer",
                type: "nvarchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "IdExercise",
                table: "Answer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdAnswer",
                table: "Answer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "IdAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_IdExercise",
                table: "Answer",
                column: "IdExercise");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Exercise_IdExercise",
                table: "Answer",
                column: "IdExercise",
                principalTable: "Exercise",
                principalColumn: "IdExercise");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Member_IdMember",
                table: "Answer",
                column: "IdMember",
                principalTable: "Member",
                principalColumn: "IdMember");
        }
    }
}
