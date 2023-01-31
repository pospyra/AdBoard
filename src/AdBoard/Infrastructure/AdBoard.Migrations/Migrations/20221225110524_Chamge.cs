using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Chamge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Ads_Id",
                table: "Photo");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AdId",
                table: "Photo",
                column: "AdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AdId",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Ads_Id",
                table: "Photo",
                column: "Id",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
