using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 3, 13, 46, 23, 708, DateTimeKind.Local).AddTicks(1688)),
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    { "11ebaeae-2995-4ca5-b156-481e6751981a", null, new DateTime(2023, 11, 3, 13, 46, 23, 708, DateTimeKind.Local).AddTicks(9145), null, "2c75293b-f8e5-4862-9b13-5894a64895cd", false, null, "Class_2", null },
                    { "d0b069eb-7be8-4482-9f15-5515227644d5", null, new DateTime(2023, 11, 3, 13, 46, 23, 708, DateTimeKind.Local).AddTicks(8954), null, "193ba283-bf34-40ad-a3be-10b1780cba0e", true, "cA4FigUKj7deRjen/4NWmw==", "Class_1", null }
                });

            migrationBuilder.InsertData(
                table: "MemberClassroom",
                columns: new[] { "IdClass", "IdUser", "Avatar", "Description", "Name", "Role" },
                values: new object[,]
                {
                    { "11ebaeae-2995-4ca5-b156-481e6751981a", "193ba283-bf34-40ad-a3be-10b1780cba0e", "", "", "", "" },
                    { "d0b069eb-7be8-4482-9f15-5515227644d5", "2c75293b-f8e5-4862-9b13-5894a64895cd", "", "", "", "" }
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
