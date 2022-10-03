using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    public partial class Add_Data_Ad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            var sql = $"INSERT INTO public.\"Ads\"(\"Id\", \"AdName\", \"CategoryId\", \"Description\", \"Price\") VALUES('{Guid.NewGuid}', 'Продам Автомобиль', '7e6ffb81-98f2-4d4c-9d96-2b2bb398b4a5', 'Hyundai solaris', 500000)";

            migrationBuilder.Sql(sql);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
