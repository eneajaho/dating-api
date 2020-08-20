using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAPI.Migrations
{
    public partial class ExtendedUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                "Birthday",
                "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                "City",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Country",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "CreatedAt",
                "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                "Gender",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Interests",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Introduction",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "KnownAs",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "LastActive",
                "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                "Photos",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AddedAt = table.Column<DateTime>(),
                    IsMain = table.Column<bool>(),
                    UserId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        "FK_Photos_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Photos_UserId",
                "Photos",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Photos");

            migrationBuilder.DropColumn(
                "Birthday",
                "Users");

            migrationBuilder.DropColumn(
                "City",
                "Users");

            migrationBuilder.DropColumn(
                "Country",
                "Users");

            migrationBuilder.DropColumn(
                "CreatedAt",
                "Users");

            migrationBuilder.DropColumn(
                "Gender",
                "Users");

            migrationBuilder.DropColumn(
                "Interests",
                "Users");

            migrationBuilder.DropColumn(
                "Introduction",
                "Users");

            migrationBuilder.DropColumn(
                "KnownAs",
                "Users");

            migrationBuilder.DropColumn(
                "LastActive",
                "Users");
        }
    }
}