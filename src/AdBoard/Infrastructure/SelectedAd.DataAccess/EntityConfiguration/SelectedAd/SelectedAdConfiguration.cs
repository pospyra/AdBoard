using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess.EntityConfiguration.SelectedAd
{
    public class SelectedAdConfiguration : IEntityTypeConfiguration<Domain.SelectedAds>
    {
        public void Configure(EntityTypeBuilder<SelectedAds> builder)
        {
            builder.ToTable("SelectedAds");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}
