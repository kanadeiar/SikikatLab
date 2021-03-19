using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLabConsole.Migrations
{
    public partial class add_hammerbinder_researches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Normal",
                table: "Researches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HammerBinderResearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Sieve0_2 = table.Column<float>(type: "real", nullable: false),
                    Surface = table.Column<float>(type: "real", nullable: false),
                    Perfomance = table.Column<float>(type: "real", nullable: false),
                    Activity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HammerBinderResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HammerBinderResearch_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HammerBinderResearch");

            migrationBuilder.DropColumn(
                name: "Normal",
                table: "Researches");
        }
    }
}
