using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class See2_SubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql1 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Грузовики' , 'a0e2d676-ce6d-4a42-aa59-901e5b4332cb')";
            var sql2 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Мотоциклы' , 'a0e2d676-ce6d-4a42-aa59-901e5b4332cb')";
            var sql3 = $"INSERT INTO public.\"Categories\" (\"Id\", \"Name\") VALUES('{Guid.NewGuid()}', 'Животные')";


            migrationBuilder.Sql(sql1);
            migrationBuilder.Sql(sql2);
            migrationBuilder.Sql(sql3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
