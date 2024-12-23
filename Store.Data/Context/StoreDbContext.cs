﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Context
{
    public class StoreDbContext : IdentityDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<product>().HasOne(x => x.prodType).WithMany(x => x.product).HasForeignKey(x => x.typID).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<product>().HasOne(x => x.prodBrand).WithMany(x => x.products).HasForeignKey(x => x.brandID).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<prodBrand>().HasOne(x => x.image).WithOne(x => x.prodBrand).HasForeignKey<prodBrand>(x => x.imageId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<imagesOnProduct>().HasKey(x => new { x.productID, x.ImageID });
            modelBuilder.Entity<ProductOnCart>().HasKey(x => new { x.productID, x.cartID });
            modelBuilder.Entity<ApplicationUser>().HasOne(x => x.image).WithOne(x => x.user).HasForeignKey<ApplicationUser>(x => x.imageID);
            modelBuilder.Entity<product>().HasMany(x => x.productVariances).WithOne(x => x.product).HasForeignKey(x => x.productID);
            modelBuilder.Entity<Cart>().HasOne(x => x.user).WithOne(x => x.cart).HasForeignKey<Cart>(x => x.userID);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<product> Products { get; set; }
        public DbSet<prodBrand> Brands { get; set; }
        public DbSet<prodType> ProdTypes { get; set; }
        public DbSet<image> images { get; set; }
        public DbSet<imagesOnProduct> imagesOnProducts { get; set; }
        public DbSet<ProductOnCart> productsOnCarts { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ProductVariance>variances { get; set; }
    }
}
