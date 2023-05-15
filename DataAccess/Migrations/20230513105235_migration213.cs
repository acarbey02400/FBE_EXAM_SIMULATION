using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class migration213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamDateTime",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "TypeExamId",
                table: "Lessons",
                newName: "LessonTime");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Studens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionTime",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Studens");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "LessonTime",
                table: "Lessons",
                newName: "TypeExamId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExamDateTime",
                table: "Lessons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
