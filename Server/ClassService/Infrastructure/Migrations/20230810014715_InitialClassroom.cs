using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 10, 8, 47, 15, 85, DateTimeKind.Local).AddTicks(5658)),
                    KeyHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdUserHost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomDetails",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdClass = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomDetails", x => new { x.IdUser, x.IdClass });
                    table.ForeignKey(
                        name: "FK_ClassroomDetails_Classrooms_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "CreateDate", "Description", "IdUserHost", "IsPrivate", "KeyHash", "Name" },
                values: new object[] { "8ab8190e-a568-4359-8668-7466f5f820ee", new DateTime(2023, 8, 10, 8, 47, 15, 86, DateTimeKind.Local).AddTicks(1578), null, "9d853125-0a15-40ee-bbc1-ee25fbdbacc1", true, "cA4FigUKj7deRjen/4NWmw==", "Class_1" });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "CreateDate", "Description", "IdUserHost", "KeyHash", "Name" },
                values: new object[] { "b1323ea9-64f7-4a39-8a61-399c6a48bc86", new DateTime(2023, 8, 10, 8, 47, 15, 86, DateTimeKind.Local).AddTicks(1734), null, "9d853125-0a15-40ee-bbc1-ee25fbdbacc1", null, "Class_2" });

            migrationBuilder.InsertData(
                table: "ClassroomDetails",
                columns: new[] { "IdClass", "IdUser", "Description", "Role" },
                values: new object[,]
                {
                    { "8ab8190e-a568-4359-8668-7466f5f820ee", "c40aa1e2-8625-4974-a0b3-ae9e75485ea3", "", "" },
                    { "b1323ea9-64f7-4a39-8a61-399c6a48bc86", "c40aa1e2-8625-4974-a0b3-ae9e75485ea3", "", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomDetails_IdClass",
                table: "ClassroomDetails",
                column: "IdClass");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomDetails");

            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
