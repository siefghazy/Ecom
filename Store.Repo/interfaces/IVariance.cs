using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface IVariance
    {
        public Task<ProductVariance> addProductVarianceAsync(ProductVariance productVariance);
        public Task<IReadOnlyList<ProductVariance>> GetProductVarianceByIdAsync(int id);
        public void updateProductVarianceAsync(ProductVariance productVariance);
        public void deleteProductVariance(int id);

    }
}
