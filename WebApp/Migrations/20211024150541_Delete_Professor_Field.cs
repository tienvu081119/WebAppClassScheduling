using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Delete_Professor_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("LastName", "Professor");
            migrationBuilder.DropColumn("FirstName", "Professor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
