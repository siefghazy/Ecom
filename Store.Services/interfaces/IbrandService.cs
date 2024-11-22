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
        public IReadOnlyList<brandDto> getAllBrands();
        public  void addBrand(brandDto brandDto);
        public brandDto getProductById(int id);
        public void updateBrand(brandDto brandDto);
        public void deleteBrand(int id);
    }
}
