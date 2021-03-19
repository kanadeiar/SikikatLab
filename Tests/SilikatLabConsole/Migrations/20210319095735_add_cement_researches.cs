using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLabConsole.Migrations
{
    public partial class add_cement_researches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CementResearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Party = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportVc = table.Column<float>(type: "real", nullable: false),
                    PassportNsh = table.Column<float>(type: "real", nullable: false),
                    PassportKsh = table.Column<float>(type: "real", nullable: false),
                    ActualVc = table.Column<float>(type: "real", nullable: false),
                    ActualNsh = table.Column<float>(type: "real", nullable: false),
                    ActualKsh = table.Column<float>(type: "real", nullable: false),
                    FromName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CementResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CementResearch_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CementResearch");
        }
    }
}
