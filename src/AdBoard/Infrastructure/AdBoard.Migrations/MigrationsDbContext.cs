using Microsoft.EntityFrameworkCore;
using SelectedAd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.Migrations
{
    public class MigrationsDbContext : SelectedAdContext
    {
        protected MigrationsDbContext(DbContextOptions<MigrationsDbContext> options) : base(options)
        {

        }
    }
}
