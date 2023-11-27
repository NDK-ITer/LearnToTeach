using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class SeviceOrchestrationdelete1row : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberModel_AddMemberStateData_AddMemberStateDataCorrelationId",
                table: "MemberModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddMemberStateDataCorrelationId",
                table: "MemberModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberModel_AddMemberStateData_AddMemberStateDataCorrelationId",
                table: "MemberModel",
                column: "AddMemberStateDataCorrelationId",
                principalTable: "AddMemberStateData",
                principalColumn: "CorrelationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberModel_AddMemberStateData_AddMemberStateDataCorrelationId",
                table: "MemberModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddMemberStateDataCorrelationId",
                table: "MemberModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberModel_AddMemberStateData_AddMemberStateDataCorrelationId",
                table: "MemberModel",
                column: "AddMemberStateDataCorrelationId",
                principalTable: "AddMemberStateData",
                principalColumn: "CorrelationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
