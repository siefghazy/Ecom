using Microsoft.AspNetCore.Http;
using Store.Data.Models;
using Store.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
   public interface IProductService
    {
        public  Task<IReadOnlyList<productDTO>> getAllProducts();
        public void addProduct(productDTO product);
        public productDTO getProductById(int id);
        public void updateProduct(product productDto);
        public void deleteProduct(int id);
        public Task addVarianceAsync(varianceAddDTO variance);
        public Task<VarianceGetDTO> VarianceGet(int id);
        public void updateVariance(int id,varianceAddDTO variance);


    }
}
