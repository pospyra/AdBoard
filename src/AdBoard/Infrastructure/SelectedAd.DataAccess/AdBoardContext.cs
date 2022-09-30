using Microsoft.EntityFrameworkCore;
using SelectedAd.DataAccess.EntityConfiguration.Ad;
using SelectedAd.DataAccess.EntityConfiguration.SelectedAd;

namespace SelectedAd.DataAccess
{
    public class AdBoardContext : DbContext
    {
        ///<summary>
        ///Инициализирует экземпляр <see cref="NsiDbContext"/>.
        ///</summary>
        protected AdBoardContext(DbContextOptions options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdConfiguration());
            modelBuilder.ApplyConfiguration(new SelectedAdConfiguration());
        }
    }
}
 