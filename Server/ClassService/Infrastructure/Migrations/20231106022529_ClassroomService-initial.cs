using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomServiceinitial : Migration
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 6, 9, 25, 29, 912, DateTimeKind.Local).AddTicks(4929)),
                    KeyHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdUserHost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameUserHost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AvatarUserHost = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberClassroom",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdClass = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberClassroom", x => new { x.IdUser, x.IdClass });
                    table.ForeignKey(
                        name: "FK_MemberClassroom_Classrooms_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "AvatarUserHost", "CreateDate", "Description", "IdUserHost", "IsPrivate", "KeyHash", "Name", "NameUserHost" },
                values: new object[,]
                {
                    { "02c47002-cc29-4b66-82bd-a86b7e3c6d5e", null, new DateTime(2023, 11, 6, 9, 25, 29, 913, DateTimeKind.Local).AddTicks(3514), null, "2c75293b-f8e5-4862-9b13-5894a64895cd", false, null, "Class_2", null },
                    { "d0186509-69d2-4a76-a0d1-69c5916c0b02", null, new DateTime(2023, 11, 6, 9, 25, 29, 913, DateTimeKind.Local).AddTicks(3247), null, "193ba283-bf34-40ad-a3be-10b1780cba0e", true, "cA4FigUKj7deRjen/4NWmw==", "Class_1", null }
                });

            migrationBuilder.InsertData(
                table: "MemberClassroom",
                columns: new[] { "IdClass", "IdUser", "Avatar", "Description", "Name", "Role" },
                values: new object[,]
                {
                    { "02c47002-cc29-4b66-82bd-a86b7e3c6d5e", "193ba283-bf34-40ad-a3be-10b1780cba0e", "", "", "test account", "" },
                    { "d0186509-69d2-4a76-a0d1-69c5916c0b02", "2c75293b-f8e5-4862-9b13-5894a64895cd", "", "", "Admin account", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberClassroom_IdClass",
                table: "MemberClassroom",
                column: "IdClass");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberClassroom");

            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
