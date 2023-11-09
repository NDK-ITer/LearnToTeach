using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class ServiceOchestrantionuppdatedellteMemberModeltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberModel");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AddMemberStateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdMember",
                table: "AddMemberStateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameMember",
                table: "AddMemberStateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MemberModel",
                columns: table => new
                {
                    idMemberModel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddMemberStateDataCorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMember = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameMember = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberModel", x => x.idMemberModel);
                    table.ForeignKey(
                        name: "FK_MemberModel_AddMemberStateData_AddMemberStateDataCorrelationId",
                        column: x => x.AddMemberStateDataCorrelationId,
                        principalTable: "AddMemberStateData",
                        principalColumn: "CorrelationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberModel_AddMemberStateDataCorrelationId",
                table: "MemberModel",
                column: "AddMemberStateDataCorrelationId");
        }
    }
}
