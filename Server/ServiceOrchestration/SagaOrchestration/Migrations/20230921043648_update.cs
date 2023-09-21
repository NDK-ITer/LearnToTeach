using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMember",
                table: "ClassroomStateData");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "ClassroomStateData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdMember",
                table: "ClassroomStateData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ClassroomStateData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
