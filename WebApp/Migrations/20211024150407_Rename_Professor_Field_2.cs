using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Rename_Professor_Field_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                 name: "Title",
                 table: "Professor",
                 newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
