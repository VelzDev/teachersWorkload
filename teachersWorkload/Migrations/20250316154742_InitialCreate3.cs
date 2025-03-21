﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teachersWorkload.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Group");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Group",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
