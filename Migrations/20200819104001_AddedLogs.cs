using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAPI.Migrations
{
    public partial class AddedLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Values");

            migrationBuilder.CreateTable(
                "Logs",
                table => new
                {
                    Id = table.Column<int>().Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(),
                    Message = table.Column<string>(nullable: true),
                    Type = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_Logs", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Logs");

            migrationBuilder.CreateTable(
                "Values",
                table => new
                {
                    Id = table.Column<int>("INTEGER")
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>("TEXT", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Values", x => x.Id); });
        }
    }
}