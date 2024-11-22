using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.Dto;
using Store.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.services
{
    public class BrandServices : IbrandService
    {
        private readonly Ibrand _brand;
        public BrandServices(Ibrand brand)
        {
            _brand = brand;
        }

        public async void  addBrand(brandDto brandDto)
        {
            prodBrand brand = new prodBrand()
            {
                ID = brandDto.id,
                Name = brandDto.Name,
            };
            await _brand.addBrandAsync(brand);
        }

        public async void deleteProduct(int id)
        {
            var product = await _brand.getBrandById(id);
            _brand.deleteBrand(product);
        }

        public async Task<IReadOnlyList<brandDto>> getAllBrandsAsync()
        {
            var brands = await _brand.getAllBrandsAsync();
            var mappedBrands = brands.Select(x => new brandDto()
            {
                id = x.ID,
                Name = x.Name,
            }).ToList();
            return mappedBrands;
        }

        public async Task<brandDto> getProductById(int id)
        {
            var brand = await _brand.getBrandById(id);
            var mappedBrand = new brandDto()
            {
                id = brand.ID,
                Name = brand.Name,
            };
            return mappedBrand;
        }

        public async void deleteBrand(int id)
        {
            var product = await _brand.getBrandById(id);
            _brand.deleteBrand(product);
        }

        public  void updateBrand(brandDto brandDto)
        {
            prodBrand brand = new prodBrand
            {
                ID = brandDto.id,
                Name = brandDto.Name,
            };
           _brand.updateBrand(brand);
        }
    }
}
