using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SelectedAd.DataAccess.EntityConfiguration.Ad
{
    public class AdConfiguration : IEntityTypeConfiguration<Domain.Ads>
    {
        public void Configure(EntityTypeBuilder<Domain.Ads> builder)
        {
            builder.ToTable("Ads");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.AdName).HasMaxLength(800);

            builder.Property(b => b.Description).HasMaxLength(2000);

            //Ad_SelectedAds
            builder.HasMany(p => p.SelectedAds)// связь один ко многим. много избранных(так как много пользователей)
                .WithOne(s => s.Ad)//у избранного - есть одно объявление(из бд)
                .HasForeignKey(s => s.AdId);//связь по внешнему ключу

            //Ad_Photos
            builder.HasMany(p => p.Photo)
                .WithOne(s => s.Ad)
                .HasForeignKey(s => s.AdId);
        }
    }
}
 