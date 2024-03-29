﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelectedAd.Domain;

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
            
            //User_Ads
            builder.HasMany(p => p.Ads)// связь один ко многим. много объяалений
                .WithOne(s => s.Users)//у пользователя - есть много объявлений
                .HasForeignKey(s => s.UsersId);//связь по внешнему ключу

            //User_Selected
            builder.HasOne(s => s.SelectedAd)
                .WithOne(u => u.User)
                .HasForeignKey<SelectedAds>(k => k.UserId);
        }
    }
}