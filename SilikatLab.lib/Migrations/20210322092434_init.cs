using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SilikatLab.lib.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laboratorians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeResearches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeResult = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeResearches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LaboratorianId = table.Column<int>(type: "int", nullable: true),
                    Access = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Laboratorians_LaboratorianId",
                        column: x => x.LaboratorianId,
                        principalTable: "Laboratorians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AgainInMinutes = table.Column<int>(type: "int", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    TypeResearchId = table.Column<int>(type: "int", nullable: true),
                    ResearchObjectId = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTasks_ResearchObjects_ResearchObjectId",
                        column: x => x.ResearchObjectId,
                        principalTable: "ResearchObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkTasks_TypeResearches_TypeResearchId",
                        column: x => x.TypeResearchId,
                        principalTable: "TypeResearches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Researches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Normal = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    WorkTaskId = table.Column<int>(type: "int", nullable: true),
                    TypeResearchId = table.Column<int>(type: "int", nullable: true),
                    ResearchObjectId = table.Column<int>(type: "int", nullable: true),
                    LaboratorianId = table.Column<int>(type: "int", nullable: false),
                    WorkShiftId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Researches_Laboratorians_LaboratorianId",
                        column: x => x.LaboratorianId,
                        principalTable: "Laboratorians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Researches_ResearchObjects_ResearchObjectId",
                        column: x => x.ResearchObjectId,
                        principalTable: "ResearchObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Researches_TypeResearches_TypeResearchId",
                        column: x => x.TypeResearchId,
                        principalTable: "TypeResearches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Researches_WorkShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Researches_WorkTasks_WorkTaskId",
                        column: x => x.WorkTaskId,
                        principalTable: "WorkTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Researches_LaboratorianId",
                table: "Researches",
                column: "LaboratorianId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_ResearchObjectId",
                table: "Researches",
                column: "ResearchObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_TypeResearchId",
                table: "Researches",
                column: "TypeResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_WorkShiftId",
                table: "Researches",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_WorkTaskId",
                table: "Researches",
                column: "WorkTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_LaboratorianId",
                table: "UserLogins",
                column: "LaboratorianId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_ResearchObjectId",
                table: "WorkTasks",
                column: "ResearchObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_TypeResearchId",
                table: "WorkTasks",
                column: "TypeResearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockQualityReearches");

            migrationBuilder.DropTable(
                name: "CementResearch");

            migrationBuilder.DropTable(
                name: "HammerBinderResearch");

            migrationBuilder.DropTable(
                name: "SludgeResearch");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Researches");

            migrationBuilder.DropTable(
                name: "Laboratorians");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "WorkTasks");

            migrationBuilder.DropTable(
                name: "ResearchObjects");

            migrationBuilder.DropTable(
                name: "TypeResearches");
        }
    }
}
