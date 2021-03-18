using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLabConsole.Migrations
{
    public partial class add_details_of_object_for_research : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResearchObjectId",
                table: "Researches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Researches_ResearchObjectId",
                table: "Researches",
                column: "ResearchObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_ResearchObjects_ResearchObjectId",
                table: "Researches",
                column: "ResearchObjectId",
                principalTable: "ResearchObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_ResearchObjects_ResearchObjectId",
                table: "Researches");

            migrationBuilder.DropIndex(
                name: "IX_Researches_ResearchObjectId",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "ResearchObjectId",
                table: "Researches");
        }
    }
}
