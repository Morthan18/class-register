using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school_management.Migrations
{
    public partial class AddSubjectToGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolSubjectId",
                table: "Grade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SchoolSubjectId",
                table: "Grade",
                column: "SchoolSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_SchoolSubject_SchoolSubjectId",
                table: "Grade",
                column: "SchoolSubjectId",
                principalTable: "SchoolSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_SchoolSubject_SchoolSubjectId",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Grade_SchoolSubjectId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "SchoolSubjectId",
                table: "Grade");
        }
    }
}
