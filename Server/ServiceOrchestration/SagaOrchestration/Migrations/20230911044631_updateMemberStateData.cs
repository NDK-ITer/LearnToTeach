﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOrchestration.Migrations
{
    /// <inheritdoc />
    public partial class updateMemberStateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberStateData",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdClassroom = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMember = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStateData", x => x.CorrelationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberStateData");
        }
    }
}