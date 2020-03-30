using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseManager.DataAccess.Migrations
{
    public partial class UpdatePresenceGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CoursePresences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CourseGrades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "CoursePresences");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CourseGrades");
        }
    }
}
