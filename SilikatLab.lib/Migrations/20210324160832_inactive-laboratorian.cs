using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLab.lib.Migrations
{
    public partial class inactivelaboratorian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Laboratorians",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Laboratorians");
        }
    }
}
