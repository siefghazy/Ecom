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
    public class varianceRepo : IVariance
    {
        private readonly StoreDbContext _context;

        public varianceRepo(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<ProductVariance> addProductVarianceAsync(ProductVariance productVariance)
        {
            ProductVariance productVarianceGet = new ProductVariance()
            {
                productID = productVariance.ID,
                colorCode = productVariance.colorCode,
                quanitity = productVariance.quanitity,
                CreatedAt = DateTime.Now,
                isDeleted = false,
            };
            _context.variances.AddAsync(productVariance);
            _context.SaveChangesAsync();
            return productVarianceGet;
        }

        public void deleteProductVariance(int id)
        {
            var variances =  _context.variances.Where(x => x.productID == id).ToList();
            _context.variances.RemoveRange(variances);
            _context.SaveChanges();
        }

        public void updateProductVarianceAsync(ProductVariance productVariance)
        {
            _context.variances.Update(productVariance);
            _context.SaveChanges();
        }

        public async  Task<IReadOnlyList<ProductVariance>> GetProductVarianceByIdAsync(int id)
        {
            return await _context.variances.Include(x => x.product).ThenInclude(product => product.productImages).ThenInclude(productImages => productImages.image).Include(x => x.product).ThenInclude(product => product.prodType).Include(x => x.product).ThenInclude(product=>product.prodBrand).ThenInclude(productbrand=>productbrand.image).Where(x => x.productID == id).ToListAsync();
        }
    }
}
