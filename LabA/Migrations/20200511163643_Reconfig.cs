using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabA.Migrations
{
    public partial class Reconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TechnologyProjects_ProjectId",
                table: "TechnologyProjects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TechnologyProjects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TechnologyName",
                table: "TechnologyProjects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Technologies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TechnologyProjects_ProjectId_TechnologyName",
                table: "TechnologyProjects",
                columns: new[] { "ProjectId", "TechnologyName" });

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
                name: "Companies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TechnologyProjects_ProjectId_TechnologyName",
                table: "TechnologyProjects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TechnologyProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TechnologyName",
                table: "TechnologyProjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Technologies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnologyProjects_ProjectId",
                table: "TechnologyProjects",
                column: "ProjectId");
        }
    }
}
