using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SelectedAd.DataAccess.EntityConfiguration.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Users>
    {
        public void Configure(EntityTypeBuilder<Domain.Users> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).HasMaxLength(100);

            builder.Property(b => b.Login).HasMaxLength(30);

            builder.Property(b => b.Password).HasMaxLength(100);

            /*
            //связь бд
            builder.HasMany(p => p.SelectedAds)// связь один ко многим. много избранных(так как много пользователей)
                .WithOne(s => s.Ad)//у избранного - есть одно объявление(из бд)
                .HasForeignKey(s => s.AdId);//связь по внешнему ключу*/
        }
    }
}
