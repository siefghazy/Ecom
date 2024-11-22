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
        public IReadOnlyList<ProductDto>getAllProducts();
        public void addProduct(ProductDto productDto);
        public ProductDto getProductById(int id);
        public void updateProduct(ProductDto productDto);
        public void deleteProduct(int id);
    }
}
