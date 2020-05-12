using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabA.Migrations
{
    public partial class RunSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "InterviewRequestVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Company = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRequestVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "InterviewRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewRequests_Companies_CompanyName",
                        column: x => x.CompanyName,
                        principalTable: "Companies",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyProjects",
                columns: table => new
                {
                    TechnologyName = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyProjects", x => new { x.TechnologyName, x.ProjectId });
                    table.UniqueConstraint("AK_TechnologyProjects_ProjectId_TechnologyName", x => new { x.ProjectId, x.TechnologyName });
                    table.ForeignKey(
                        name: "FK_TechnologyProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechnologyProjects_Technologies_TechnologyName",
                        column: x => x.TechnologyName,
                        principalTable: "Technologies",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequests_CompanyName",
                table: "InterviewRequests",
                column: "CompanyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewRequests");

            migrationBuilder.DropTable(
                name: "InterviewRequestVM");

            migrationBuilder.DropTable(
                name: "TechnologyProjects");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
