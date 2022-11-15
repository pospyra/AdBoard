using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Add_SubCatInAds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Ads",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Ads");
        }
    }
}
