﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data.Context;

#nullable disable

namespace Store.Data.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Data.Models.image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("images");
                });

            modelBuilder.Entity("Store.Data.Models.imagesOnProduct", b =>
                {
                    b.Property<int>("imagesID")
                        .HasColumnType("int");

                    b.Property<int>("productsID")
                        .HasColumnType("int");

                    b.HasKey("imagesID", "productsID");

                    b.HasIndex("productsID");

                    b.ToTable("imagesOnProducts");
                });

            modelBuilder.Entity("Store.Data.Models.prodBrand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("imageId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("imageId")
                        .IsUnique()
                        .HasFilter("[imageId] IS NOT NULL");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Store.Data.Models.prodType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("ProdTypes");
                });

            modelBuilder.Entity("Store.Data.Models.product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("brandID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("typID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("brandID");

                    b.HasIndex("typID")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Store.Data.Models.imagesOnProduct", b =>
                {
                    b.HasOne("Store.Data.Models.image", null)
                        .WithMany()
                        .HasForeignKey("imagesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Data.Models.product", null)
                        .WithMany()
                        .HasForeignKey("productsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Store.Data.Models.prodBrand", b =>
                {
                    b.HasOne("Store.Data.Models.image", "image")
                        .WithOne("prodBrand")
                        .HasForeignKey("Store.Data.Models.prodBrand", "imageId");

                    b.Navigation("image");
                });

            modelBuilder.Entity("Store.Data.Models.product", b =>
                {
                    b.HasOne("Store.Data.Models.prodBrand", "prodBrand")
                        .WithMany("products")
                        .HasForeignKey("brandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Data.Models.prodType", "prodType")
                        .WithOne("product")
                        .HasForeignKey("Store.Data.Models.product", "typID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("prodBrand");

                    b.Navigation("prodType");
                });

            modelBuilder.Entity("Store.Data.Models.image", b =>
                {
                    b.Navigation("prodBrand")
                        .IsRequired();
                });

            modelBuilder.Entity("Store.Data.Models.prodBrand", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Store.Data.Models.prodType", b =>
                {
                    b.Navigation("product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
