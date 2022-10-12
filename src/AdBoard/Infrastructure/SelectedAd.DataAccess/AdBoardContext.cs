using Microsoft.EntityFrameworkCore;
using SelectedAd.DataAccess.EntityConfiguration.Ad;
using SelectedAd.DataAccess.EntityConfiguration.SelectedAd;
using System.Reflection;

namespace SelectedAd.DataAccess
{
    public class AdBoardContext : DbContext
    {
        ///<summary>
        ///Инициализирует экземпляр <see cref="NsiDbContext"/>.
        ///</summary>
        public AdBoardContext(DbContextOptions options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
        }
    }
}
 