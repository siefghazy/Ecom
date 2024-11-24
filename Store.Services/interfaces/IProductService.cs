using Store.Data.Models;
using Store.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
   public interface IProductService
    {
        public IReadOnlyList<product>getAllProducts();
        public void addProduct(product productDto);
        public product getProductById(int id);
        public void updateProduct(product productDto);
        public void deleteProduct(int id);
    }
}
