using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess.EntityConfiguration.Photo
{
    public class PhotoCongiguration : IEntityTypeConfiguration<Domain.Photo>
    {
        public void Configure(EntityTypeBuilder<Domain.Photo> builder)
        {
            builder.ToTable("Photo");

            builder.HasKey(p => p.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

           // builder.Property(x => x.KodBase64).IsRequired();

            //builder.HasOne(x => x.Ad)
            //   .WithMany(x => x.Photo)
            //   .HasForeignKey(s => s.AdId);
        }
    }
}
