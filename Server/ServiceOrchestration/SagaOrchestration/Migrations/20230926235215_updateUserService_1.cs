using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class updateUserService_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_confirmUserEmailStateDatas",
                table: "confirmUserEmailStateDatas");

            migrationBuilder.RenameTable(
                name: "confirmUserEmailStateDatas",
                newName: "ConfirmUserEmailStateData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmUserEmailStateData",
                table: "ConfirmUserEmailStateData",
                column: "CorrelationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmUserEmailStateData",
                table: "ConfirmUserEmailStateData");

            migrationBuilder.RenameTable(
                name: "ConfirmUserEmailStateData",
                newName: "confirmUserEmailStateDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_confirmUserEmailStateDatas",
                table: "confirmUserEmailStateDatas",
                column: "CorrelationId");
        }
    }
}
