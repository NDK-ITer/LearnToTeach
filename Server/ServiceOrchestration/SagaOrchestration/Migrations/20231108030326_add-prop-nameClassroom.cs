using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class addpropnameClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AddMemberStateData");

            migrationBuilder.DropColumn(
                name: "IdMember",
                table: "AddMemberStateData");

            migrationBuilder.DropColumn(
                name: "NameMember",
                table: "AddMemberStateData");

            migrationBuilder.AddColumn<string>(
                name: "NameClassroom",
                table: "AddMemberStateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MemberModel",
                columns: table => new
                {
                    idMemberModel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMember = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameMember = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddMemberStateDataCorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberModel", x => x.idMemberModel);
                    table.ForeignKey(
                        name: "FK_MemberModel_AddMemberStateData_AddMemberStateDataCorrelationId",
                        column: x => x.AddMemberStateDataCorrelationId,
                        principalTable: "AddMemberStateData",
                        principalColumn: "CorrelationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberModel_AddMemberStateDataCorrelationId",
                table: "MemberModel",
                column: "AddMemberStateDataCorrelationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberModel");

            migrationBuilder.DropColumn(
                name: "NameClassroom",
                table: "AddMemberStateData");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AddMemberStateData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdMember",
                table: "AddMemberStateData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameMember",
                table: "AddMemberStateData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
