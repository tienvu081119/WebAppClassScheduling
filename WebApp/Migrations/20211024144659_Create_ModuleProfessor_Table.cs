using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Create_ModuleProfessor_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfessorsId",
                table: "Professor",
                newName: "ProfessorId");

            migrationBuilder.CreateTable(
                name: "ModuleProfessor",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleProfessor", x => new { x.ModuleId, x.ProfessorId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleProfessor");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Professor",
                newName: "ProfessorsId");
        }
    }
}
