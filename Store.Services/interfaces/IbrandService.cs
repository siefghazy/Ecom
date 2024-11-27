using Store.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface IbrandService
    {
        public IReadOnlyList<prodBrand> getAllBrands();
        public  void addBrand(prodBrand brandDto);
        public prodBrand getProductById(int ?id);
        public void updateBrand(int ?id,prodBrand brandDto);
        public void deleteBrand(int ?id);
    }
}
