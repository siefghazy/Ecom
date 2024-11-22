using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Store.Repo.repos
{
    public class ProductRepo : IProduct
    {
        private readonly StoreDbContext _Context;
        public ProductRepo(StoreDbContext context)
        {
            _Context = context;
        }

        public async Task addProductAsync(product product)
        {
            await _Context.Products.AddAsync(product);
            await _Context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<product>> getAllProductsAsync()
        {
            return await _Context.Products.Include(x=>x.prodBrand).Include(x=>x.prodType).ToListAsync();
        }

        public async Task<product> getPrdouctById(int id)
        {
            return await _Context.Products.Include(x => x.prodBrand).Include(x => x.prodType).FirstOrDefaultAsync(x => x.ID == id);
        }

        public void updateProduct(product product)
        {
            _Context.Products.Update(product);
             _Context.SaveChanges();
        }

        void IProduct.removeProduct(product product)
        {
            _Context.Products.Remove(product);
            _Context.SaveChanges();
        }
    }
}
