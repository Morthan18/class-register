using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_management.Migrations
{
    public partial class Addclasstostudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Student",
                newName: "classId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                newName: "IX_Student_classId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_classId",
                table: "Student",
                column: "classId",
                principalTable: "Class",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_classId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "classId",
                table: "Student",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_classId",
                table: "Student",
                newName: "IX_Student_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");
        }
    }
}
