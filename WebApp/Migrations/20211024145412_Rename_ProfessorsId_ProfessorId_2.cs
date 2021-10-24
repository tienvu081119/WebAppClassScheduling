using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Rename_ProfessorsId_ProfessorId_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "ProfessorsId",
            table: "Professor",
            newName: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "ProfessorsId",
            table: "Professor",
            newName: "ProfessorId");
        }
    }
}
