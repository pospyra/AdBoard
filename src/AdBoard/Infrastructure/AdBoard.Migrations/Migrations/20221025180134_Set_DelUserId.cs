using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Set_DelUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Ads",
                type: "uuid",
                nullable: true);
        }
    }
}
