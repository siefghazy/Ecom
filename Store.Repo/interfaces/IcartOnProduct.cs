using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
     public interface IcartOnProduct
    {
        public Task addCartOnProductAsync(ProductOnCart productOnCart);
        public void updateCartOnProduct(ProductOnCart productOnCart);
        public Task<IReadOnlyList<ProductOnCart>> GetProductOnCartsById(int id);
    }
}
