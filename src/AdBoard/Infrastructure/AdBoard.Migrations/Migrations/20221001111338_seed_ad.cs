using Microsoft.EntityFrameworkCore.Migrations;
using SelectedAd.Domain;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class seed_ad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql =
                $"INSERT INTO public.\"Ads\"(\"Id\", \"AdName\", \"CategoryId\", \"Description\", \"Price\", \"CategoriesId\") VALUES(?, ?, ?, ?, ?, ?)"; 
            migrationBuilder.Sql(sql);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
