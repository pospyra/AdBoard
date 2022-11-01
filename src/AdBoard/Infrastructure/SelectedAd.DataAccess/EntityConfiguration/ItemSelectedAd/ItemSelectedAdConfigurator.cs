using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess.EntityConfiguration.ItemSelectedAd
{
    public class ItemSelectedAdConfigurator : IEntityTypeConfiguration<Domain.ItemSelectedAd>
    {
        public void Configure(EntityTypeBuilder<Domain.ItemSelectedAd> builder)
        {
            builder.ToTable("ItemSelectedAd");
            {
                builder.HasKey(b => b.SelectedId);
                builder.HasOne(a => a.Ad);
                builder.HasOne(s=>s.SelectedAds)
                    .WithMany(m=>m.Ads)
                    .HasForeignKey(k => k.SelectedId);
            }
        }
    }
}