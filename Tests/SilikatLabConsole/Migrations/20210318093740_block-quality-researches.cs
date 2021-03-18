using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLabConsole.Migrations
{
    public partial class blockqualityresearches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockQualityReearches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Trademark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    SizeX = table.Column<float>(type: "real", nullable: false),
                    SizeY = table.Column<float>(type: "real", nullable: false),
                    SizeZ = table.Column<float>(type: "real", nullable: false),
                    BeforeDensity = table.Column<float>(type: "real", nullable: false),
                    Coefficient = table.Column<float>(type: "real", nullable: false),
                    BeforeWeight = table.Column<float>(type: "real", nullable: false),
                    AfterWeight = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    Load = table.Column<float>(type: "real", nullable: false),
                    Strength = table.Column<float>(type: "real", nullable: false),
                    AfterDensity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockQualityReearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockQualityReearches_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockQualityReearches");
        }
    }
}
