using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class principalkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id");
        }
    }
}
