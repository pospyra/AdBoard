using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class User_SelectedAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SelectedAds",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAds_UserId",
                table: "SelectedAds",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedAds_Users_UserId",
                table: "SelectedAds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedAds_Users_UserId",
                table: "SelectedAds");

            migrationBuilder.DropIndex(
                name: "IX_SelectedAds_UserId",
                table: "SelectedAds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SelectedAds");
        }
    }
}
