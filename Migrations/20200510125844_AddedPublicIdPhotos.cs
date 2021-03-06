﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAPI.Migrations
{
    public partial class AddedPublicIdPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "PublicId",
                "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PublicId",
                "Photos");
        }
    }
}