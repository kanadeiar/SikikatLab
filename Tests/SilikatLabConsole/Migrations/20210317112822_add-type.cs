using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLabConsole.Migrations
{
    public partial class addtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeResult",
                table: "TypeResearches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeResult",
                table: "TypeResearches");
        }
    }
}
