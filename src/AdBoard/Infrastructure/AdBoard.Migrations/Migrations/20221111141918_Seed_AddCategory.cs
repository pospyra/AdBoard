using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Seed_AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql1 = $"INSERT INTO public.\"Categories\" (\"Id\", \"Name\") VALUES('{Guid.NewGuid()}', 'Услуги')";
            var sql2 = $"INSERT INTO public.\"Categories\" (\"Id\", \"Name\") VALUES('{Guid.NewGuid()}', 'Недвижимость')";
            var sql3 = $"INSERT INTO public.\"Categories\" (\"Id\", \"Name\") VALUES('{Guid.NewGuid()}', 'Одежда')";
            var sql4 = $"INSERT INTO public.\"Categories\" (\"Id\", \"Name\") VALUES('{Guid.NewGuid()}', 'Электронника')";

            migrationBuilder.Sql(sql1);
            migrationBuilder.Sql(sql2);
            migrationBuilder.Sql(sql3);
            migrationBuilder.Sql(sql4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
