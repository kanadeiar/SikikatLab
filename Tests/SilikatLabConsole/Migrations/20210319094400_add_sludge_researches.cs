using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLabConsole.Migrations
{
    public partial class add_sludge_researches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SludgeResearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Density = table.Column<float>(type: "real", nullable: false),
                    Surface = table.Column<float>(type: "real", nullable: false),
                    Sieve0_8 = table.Column<float>(type: "real", nullable: false),
                    Sieve0_09 = table.Column<float>(type: "real", nullable: false),
                    Sieve0_045 = table.Column<float>(type: "real", nullable: false),
                    Gypsum = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SludgeResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SludgeResearch_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SludgeResearch");
        }
    }
}
