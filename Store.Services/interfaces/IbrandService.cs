using Store.Data.Models;
using Store.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface IbrandService
    {
        public IReadOnlyList<BrandDto> getAllBrands();
      //  public  void addBrand(BrandDto brandDto);
        public BrandDto getProductById(int ?id);
        public void updateBrand(int id,BrandDto brandDto);
        public void deleteBrand(int ?id);
    }
}
