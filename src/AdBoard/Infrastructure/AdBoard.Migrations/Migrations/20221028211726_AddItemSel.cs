using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class AddItemSel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SelectedAds");

            migrationBuilder.CreateTable(
                name: "ItemSelectedAd",
                columns: table => new
                {
                    SelectedId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSelectedAd", x => x.SelectedId);
                    table.ForeignKey(
                        name: "FK_ItemSelectedAd_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSelectedAd_SelectedAds_SelectedId",
                        column: x => x.SelectedId,
                        principalTable: "SelectedAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSelectedAd_AdId",
                table: "ItemSelectedAd",
                column: "AdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSelectedAd");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SelectedAds",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
