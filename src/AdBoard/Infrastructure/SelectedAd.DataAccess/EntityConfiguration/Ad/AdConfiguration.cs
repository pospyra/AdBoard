using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SelectedAd.DataAccess.EntityConfiguration.Ad
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Ad>
    {
        public void Configure(EntityTypeBuilder<Domain.Ad> builder)
        {
            builder.ToTable("Ads");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.AdName).HasMaxLength(800);

            builder.HasMany(p => p.SelectedAds)//много избранных(так как много пользщователей)
                .WithOne(s => s.Ad)//у избранного - есть одно объявление(из бд)
                .HasForeignKey(s => s.AdId);//связь по внешнему ключу
        }
    }
}
