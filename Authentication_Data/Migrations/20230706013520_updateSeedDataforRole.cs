using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication_Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedDataforRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "Description", "Name", "NormalizeName" },
                values: new object[,]
                {
                    { "58ee6afb-1349-4d16-87fe-6ab3bddea59a", "", "ADMIN", "Admin" },
                    { "61f034ea-331e-417e-9958-986894374b48", "", "MANAGER", "Manager" },
                    { "a2f949b8-c668-4432-833d-4a3efea89233", "", "USER", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: "58ee6afb-1349-4d16-87fe-6ab3bddea59a");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: "61f034ea-331e-417e-9958-986894374b48");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: "a2f949b8-c668-4432-833d-4a3efea89233");
        }
    }
}
