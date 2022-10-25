using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Ad_UserIdNullabl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Ads",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UsersId",
                table: "Ads",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UsersId",
                table: "Ads",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
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
        }
    }
}
