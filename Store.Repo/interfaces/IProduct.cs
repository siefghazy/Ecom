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
        public IReadOnlyList<product>getAllProducts();
        public product getPrdouctById(int id);
        public void addProduct(product product);
        public void updateProduct(product product);
        public void removeProduct(product product);
        public product addProductGet(product product);
    }
}
