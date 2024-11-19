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
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<product>().HasOne(x => x.prodType).WithOne(x => x.product).HasForeignKey<product>(x => x.typID);
            modelBuilder.Entity<product>().HasOne(x => x.prodBrand).WithMany(x => x.products).HasForeignKey(x => x.brandID);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<product> Products { get; set; }
        public DbSet<prodBrand> Brands { get; set; }
        public DbSet<prodType> ProdTypes { get; set; }
    }
}
