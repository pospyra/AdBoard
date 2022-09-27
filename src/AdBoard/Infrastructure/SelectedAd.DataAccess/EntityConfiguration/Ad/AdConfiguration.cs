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

            builder.HasMany(p => p.SelectedAds)
                .WithOne(s => s.Ad)
                .HasForeignKey(s => s.AdId);
        }
    }
}
