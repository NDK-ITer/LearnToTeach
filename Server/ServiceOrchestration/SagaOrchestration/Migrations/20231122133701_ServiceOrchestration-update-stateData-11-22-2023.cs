using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class ServiceOrchestrationupdatestateData11222023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UploadFileStateData",
                newName: "IdMessage");

            migrationBuilder.AddColumn<string>(
                name: "IdObject",
                table: "UploadFileStateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdClassroom",
                table: "MemberStateData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdMessage",
                table: "MemberStateData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "IdClassroom",
                table: "ClassroomStateData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdMessage",
                table: "ClassroomStateData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdObject",
                table: "UploadFileStateData");

            migrationBuilder.DropColumn(
                name: "IdMessage",
                table: "MemberStateData");

            migrationBuilder.DropColumn(
                name: "IdMessage",
                table: "ClassroomStateData");

            migrationBuilder.RenameColumn(
                name: "IdMessage",
                table: "UploadFileStateData",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdClassroom",
                table: "MemberStateData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdClassroom",
                table: "ClassroomStateData",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
