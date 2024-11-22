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

        public void addBrand(prodBrand prodBrand)
        {
            var image=prodBrand.imageId;
             _Context.Brands.Add(prodBrand);
             _Context.SaveChanges();
        }

        public void deleteBrand(prodBrand brand)
        {
            _Context.Brands.Remove(brand);
            _Context.SaveChanges();
        }

        public IReadOnlyList<prodBrand> getAllBrands()
        {
          return _Context.Brands.Include(x=>x.image).ToList();
        }

        public prodBrand getBrandById(int id)
        {
            return  _Context.Brands.Include(x=>x.image).FirstOrDefault(x=>x.ID==id);
        }

        public void updateBrand(prodBrand prodBrand)
        {
            _Context.Brands.Update(prodBrand);
            _Context.SaveChanges();
        }
    }
}
