using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Seed_SubCaregory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Categories");

            var sql = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Запчасти' , 'a0e2d676-ce6d-4a42-aa59-901e5b4332cb')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubCategory",
                table: "Categories",
                type: "uuid",
                nullable: true);
        }
    }
}
