using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SelectedAd.DataAccess.EntityConfiguration.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Categories>
    {
        public void Configure(EntityTypeBuilder<Domain.Categories> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).HasMaxLength(800);

            //связь бд
            builder.HasMany(p => p.Ad)// связь один ко многим. много объяалений
                .WithOne(s => s.Category)//у категории - есть много объявлений
                .HasForeignKey(s => s.CategoryId);//связь по внешнему ключу
        }
    }  
}
