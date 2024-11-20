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
        public Task<IReadOnlyList<ProductDto>> getAllProductsAsync();
        public Task<IReadOnlyList<brandDto>> getAllBrandAsync();
        public Task<IReadOnlyList<brandDto>> getAllTypesAsync();
        public Task<ProductDto>getProductById(int id);
    }
}
