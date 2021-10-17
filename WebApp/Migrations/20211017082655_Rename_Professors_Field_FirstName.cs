using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Rename_Professors_Field_FirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "FristName", table: "Professor", newName: "FirstName", schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "FristName", table: "Professor", newName: "FirstName", schema: "dbo");
        }
    }
}
