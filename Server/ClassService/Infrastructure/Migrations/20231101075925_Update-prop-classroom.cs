using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatepropclassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassroomDetails",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "8ab8190e-a568-4359-8668-7466f5f820ee", "c40aa1e2-8625-4974-a0b3-ae9e75485ea3" });

            migrationBuilder.DeleteData(
                table: "ClassroomDetails",
                keyColumns: new[] { "IdClass", "IdUser" },
                keyValues: new object[] { "b1323ea9-64f7-4a39-8a61-399c6a48bc86", "c40aa1e2-8625-4974-a0b3-ae9e75485ea3" });

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "8ab8190e-a568-4359-8668-7466f5f820ee");

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: "b1323ea9-64f7-4a39-8a61-399c6a48bc86");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrivate",
                table: "Classrooms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 1, 14, 59, 25, 750, DateTimeKind.Local).AddTicks(8166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 10, 8, 47, 15, 85, DateTimeKind.Local).AddTicks(5658));

            migrationBuilder.AddColumn<string>(
                name: "AvatarUserHost",
                table: "Classrooms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameUserHost",
                table: "Classrooms",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "ClassroomDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClassroomDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUserHost",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "NameUserHost",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "ClassroomDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClassroomDetails");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrivate",
                table: "Classrooms",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 10, 8, 47, 15, 85, DateTimeKind.Local).AddTicks(5658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 1, 14, 59, 25, 750, DateTimeKind.Local).AddTicks(8166));

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
        }
    }
}
