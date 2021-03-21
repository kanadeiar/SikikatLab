using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLabConsole.Migrations
{
    public partial class non_required_field_task : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_WorkTasks_WorkTaskId",
                table: "Researches");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "WorkTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "WorkTaskId",
                table: "Researches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeResearchId",
                table: "Researches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Researches_TypeResearchId",
                table: "Researches",
                column: "TypeResearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_TypeResearches_TypeResearchId",
                table: "Researches",
                column: "TypeResearchId",
                principalTable: "TypeResearches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_WorkTasks_WorkTaskId",
                table: "Researches",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_TypeResearches_TypeResearchId",
                table: "Researches");

            migrationBuilder.DropForeignKey(
                name: "FK_Researches_WorkTasks_WorkTaskId",
                table: "Researches");

            migrationBuilder.DropIndex(
                name: "IX_Researches_TypeResearchId",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "TypeResearchId",
                table: "Researches");

            migrationBuilder.AlterColumn<int>(
                name: "WorkTaskId",
                table: "Researches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_WorkTasks_WorkTaskId",
                table: "Researches",
                column: "WorkTaskId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
