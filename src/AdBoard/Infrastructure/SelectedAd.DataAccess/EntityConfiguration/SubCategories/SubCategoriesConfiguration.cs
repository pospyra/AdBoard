using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess.EntityConfiguration.SubCategories
{
    public class SubCategoriesConfiguration : IEntityTypeConfiguration<Domain.SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable ("SubCategory");
            builder.HasKey (c => c.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}
