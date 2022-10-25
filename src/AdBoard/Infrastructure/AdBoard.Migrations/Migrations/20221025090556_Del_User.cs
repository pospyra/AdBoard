using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Del_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UserId",
                table: "Ads");

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Ads",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UsersId",
                table: "Ads",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UsersId",
                table: "Ads",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UsersId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UsersId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Ads");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UserId",
                table: "Ads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
