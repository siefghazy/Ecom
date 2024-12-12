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
    public class CartOnProductRepo : IcartOnProduct
    {
        private readonly StoreDbContext _context;

        public CartOnProductRepo(StoreDbContext context)
        {
            _context = context;
        }

        public async Task addCartOnProductAsync(ProductOnCart productOnCart)
        {
           await  _context.productsOnCarts.AddAsync(productOnCart);
            await _context.SaveChangesAsync();
        }

        public void updateCartOnProduct(ProductOnCart productOnCart)
        {
            _context.productsOnCarts.Update(productOnCart);
        }

        public async  Task<IReadOnlyList<ProductOnCart>> GetProductOnCartsById(int id)
        {
            return await _context.productsOnCarts.Where(x => x.cartID == id).Include(x=>x.product).ToListAsync();
        }
    }
}
