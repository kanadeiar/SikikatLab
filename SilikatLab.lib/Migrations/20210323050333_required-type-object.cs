using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLab.lib.Migrations
{
    public partial class requiredtypeobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_ResearchObjects_ResearchObjectId",
                table: "Researches");

            migrationBuilder.DropForeignKey(
                name: "FK_Researches_TypeResearches_TypeResearchId",
                table: "Researches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypeResearches",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeResearchId",
                table: "Researches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResearchObjectId",
                table: "Researches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_ResearchObjects_ResearchObjectId",
                table: "Researches",
                column: "ResearchObjectId",
                principalTable: "ResearchObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_TypeResearches_TypeResearchId",
                table: "Researches",
                column: "TypeResearchId",
                principalTable: "TypeResearches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_ResearchObjects_ResearchObjectId",
                table: "Researches");

            migrationBuilder.DropForeignKey(
                name: "FK_Researches_TypeResearches_TypeResearchId",
                table: "Researches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypeResearches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "TypeResearchId",
                table: "Researches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResearchObjectId",
                table: "Researches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_ResearchObjects_ResearchObjectId",
                table: "Researches",
                column: "ResearchObjectId",
                principalTable: "ResearchObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_TypeResearches_TypeResearchId",
                table: "Researches",
                column: "TypeResearchId",
                principalTable: "TypeResearches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
