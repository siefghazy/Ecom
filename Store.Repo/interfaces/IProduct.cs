using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface IProduct
    {
        public Task<IReadOnlyList<product>> getAllProductsAsync();
        public Task<product> getPrdouctById(int id);
        public Task addProductAsync(product product);
        public void updateProduct(product product);
        public void removeProduct(product product);
    }
}
