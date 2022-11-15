using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Seed_SubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Сидинг для одежды
            var sql1 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Детское' , '4b97d988-d2dd-47f8-aedb-50e3d7264955')";
            var sql2 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Женское' , '4b97d988-d2dd-47f8-aedb-50e3d7264955')";
            var sql3 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Мужское' , '4b97d988-d2dd-47f8-aedb-50e3d7264955')";
            var sql4 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Зимнее' , '4b97d988-d2dd-47f8-aedb-50e3d7264955')";
            var sql5 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Летнее' , '4b97d988-d2dd-47f8-aedb-50e3d7264955')";

            //Сидинг для электронники
            var sql6 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Телефоны' , 'a09c4c11-2885-4dff-97d0-8e35f594f5f3')";
            var sql7 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Планшеты' , 'a09c4c11-2885-4dff-97d0-8e35f594f5f3')";
            var sql8 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Ноутбуки' , 'a09c4c11-2885-4dff-97d0-8e35f594f5f3')";
            var sql9 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Компьютеры' , 'a09c4c11-2885-4dff-97d0-8e35f594f5f3')";
            var sql10 = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Аксессуары' , 'a09c4c11-2885-4dff-97d0-8e35f594f5f3')";


            migrationBuilder.Sql(sql1);
            migrationBuilder.Sql(sql2);
            migrationBuilder.Sql(sql3);
            migrationBuilder.Sql(sql4);
            migrationBuilder.Sql(sql5);

            migrationBuilder.Sql(sql6);
            migrationBuilder.Sql(sql7);
            migrationBuilder.Sql(sql8);
            migrationBuilder.Sql(sql9);
            migrationBuilder.Sql(sql10);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
