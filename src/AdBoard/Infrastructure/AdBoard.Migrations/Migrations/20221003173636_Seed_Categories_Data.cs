using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Seed_Categories_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sql = $"INSERT INTO public.\"Categories\" (\"Id\", \"Name\") VALUES('{Guid.NewGuid()}', 'Авто')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
