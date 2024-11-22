using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface Ibrand
    {
        public Task<IReadOnlyList<prodBrand>> getAllBrandsAsync();
        public Task<prodBrand> getBrandById(int id);
        public Task addBrandAsync(prodBrand prodBrand);
        public void updateBrand(prodBrand prodBrand);
        public void deleteBrand(prodBrand brand);
    }
}
