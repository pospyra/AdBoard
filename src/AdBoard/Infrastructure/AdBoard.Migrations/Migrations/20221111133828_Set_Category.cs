using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Set_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = $"INSERT INTO public.\"SubCategory\" (\"Id\", \"Name\" , \"CategoryId\") VALUES('{Guid.NewGuid()}', 'Легковые машины' , 'a0e2d676-ce6d-4a42-aa59-901e5b4332cb')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
