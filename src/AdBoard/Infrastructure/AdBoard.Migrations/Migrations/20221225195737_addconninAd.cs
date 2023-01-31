using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class addconninAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdId",
                table: "Photo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "AdId",
                table: "Photo",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Ads_AdId",
                table: "Photo",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id");
        }
    }
}
