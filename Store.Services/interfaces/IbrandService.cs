using Store.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface IbrandService
    {
        public Task<IReadOnlyList<brandDto>> getAllBrandsAsync();
        public  void addBrand(brandDto brandDto);
        public Task<brandDto> getProductById(int id);
        public void updateBrand(brandDto brandDto);
        public void deleteBrand(int id);
    }
}
