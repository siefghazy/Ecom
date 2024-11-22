using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.repos
{
    public class BrandsRepo:Ibrand
    {
        private readonly StoreDbContext _Context;
        public BrandsRepo(StoreDbContext context)
        {
            _Context = context;
        }

        public async Task addBrandAsync(prodBrand prodBrand)
        {
            await _Context.Brands.AddAsync(prodBrand);
            await _Context.SaveChangesAsync();
        }

        public void deleteBrand(prodBrand brand)
        {
            _Context.Brands.Remove(brand);
            _Context.SaveChanges();
        }

        public async Task<IReadOnlyList<prodBrand>> getAllBrandsAsync()
        {
          return await _Context.Brands.ToListAsync();
        }

        public async Task<prodBrand> getBrandById(int id)
        {
            return await _Context.Brands.FindAsync(id);
        }

        public void updateBrand(prodBrand prodBrand)
        {
            _Context.Brands.Update(prodBrand);
            _Context.SaveChanges();
        }
    }
}
