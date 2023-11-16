using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class ServerOchestrationupdatecolumname11112023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_updateUserInforStateDatas",
                table: "updateUserInforStateDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddMemberStateData",
                table: "AddMemberStateData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddClassroomStateData",
                table: "AddClassroomStateData");

            migrationBuilder.RenameTable(
                name: "updateUserInforStateDatas",
                newName: "UpdateUserInforStateData");

            migrationBuilder.RenameTable(
                name: "AddMemberStateData",
                newName: "MemberStateData");

            migrationBuilder.RenameTable(
                name: "AddClassroomStateData",
                newName: "ClassroomStateData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UpdateUserInforStateData",
                table: "UpdateUserInforStateData",
                column: "CorrelationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberStateData",
                table: "MemberStateData",
                column: "CorrelationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassroomStateData",
                table: "ClassroomStateData",
                column: "CorrelationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UpdateUserInforStateData",
                table: "UpdateUserInforStateData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberStateData",
                table: "MemberStateData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassroomStateData",
                table: "ClassroomStateData");

            migrationBuilder.RenameTable(
                name: "UpdateUserInforStateData",
                newName: "updateUserInforStateDatas");

            migrationBuilder.RenameTable(
                name: "MemberStateData",
                newName: "AddMemberStateData");

            migrationBuilder.RenameTable(
                name: "ClassroomStateData",
                newName: "AddClassroomStateData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_updateUserInforStateDatas",
                table: "updateUserInforStateDatas",
                column: "CorrelationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddMemberStateData",
                table: "AddMemberStateData",
                column: "CorrelationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddClassroomStateData",
                table: "AddClassroomStateData",
                column: "CorrelationId");
        }
    }
}
