﻿// <auto-generated />
using System;
using AdBoard.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdBoard.Migrations.Migrations
{
    [DbContext(typeof(MigrationsDbContext))]
    [Migration("20221223192134_delconnect")]
    partial class delconnect
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SelectedAd.Domain.Ads", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdName")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<bool>("PossibleOfDelivery")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<Guid?>("SubCategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UsersId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UsersId");

                    b.ToTable("Ads", (string)null);
                });

            modelBuilder.Entity("SelectedAd.Domain.Categories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("SelectedAd.Domain.ItemSelectedAd", b =>
                {
                    b.Property<Guid>("SelectedId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("SelectedId");

                    b.HasIndex("AdId");

                    b.ToTable("ItemSelectedAd", (string)null);
                });

            modelBuilder.Entity("SelectedAd.Domain.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uuid");

                    b.Property<string>("KodBase64")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Photo", (string)null);
                });

            modelBuilder.Entity("SelectedAd.Domain.SelectedAds", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SelectedAds", (string)null);
                });

            modelBuilder.Entity("SelectedAd.Domain.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory", (string)null);
                });

            modelBuilder.Entity("SelectedAd.Domain.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("SelectedAd.Domain.Ads", b =>
                {
                    b.HasOne("SelectedAd.Domain.Categories", "Category")
                        .WithMany("Ad")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SelectedAd.Domain.Users", "Users")
                        .WithMany("Ads")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SelectedAd.Domain.ItemSelectedAd", b =>
                {
                    b.HasOne("SelectedAd.Domain.Ads", "Ad")
                        .WithMany()
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SelectedAd.Domain.SelectedAds", "SelectedAds")
                        .WithMany("Ads")
                        .HasForeignKey("SelectedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("SelectedAds");
                });

            modelBuilder.Entity("SelectedAd.Domain.Photo", b =>
                {
                    b.HasOne("SelectedAd.Domain.Ads", "Ad")
                        .WithMany("Photo")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("SelectedAd.Domain.SelectedAds", b =>
                {
                    b.HasOne("SelectedAd.Domain.Ads", "Ad")
                        .WithMany("SelectedAds")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SelectedAd.Domain.Users", "User")
                        .WithOne("SelectedAd")
                        .HasForeignKey("SelectedAd.Domain.SelectedAds", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SelectedAd.Domain.SubCategory", b =>
                {
                    b.HasOne("SelectedAd.Domain.Categories", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SelectedAd.Domain.Ads", b =>
                {
                    b.Navigation("Photo");

                    b.Navigation("SelectedAds");
                });

            modelBuilder.Entity("SelectedAd.Domain.Categories", b =>
                {
                    b.Navigation("Ad");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("SelectedAd.Domain.SelectedAds", b =>
                {
                    b.Navigation("Ads");
                });

            modelBuilder.Entity("SelectedAd.Domain.Users", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("SelectedAd");
                });
#pragma warning restore 612, 618
        }
    }
}
