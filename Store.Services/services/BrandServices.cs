using ECOMMERECE.helper;
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

        public  void  addBrand(brandDto brandDto)
        {
            var brandImage = documentSetting.uploadFile(brandDto.FormImage, "images");
            prodBrand brand = new prodBrand()
            {
                ID = brandDto.id,
                Name = brandDto.Name,

            };
             _brand.addBrand(brand);
        }

        public  void deleteProduct(int id)
        {
            var product =  _brand.getBrandById(id);
            _brand.deleteBrand(product);
        }

        public  IReadOnlyList<brandDto> getAllBrands()
        {
            var brands =  _brand.getAllBrands();
            var mappedBrands = brands.Select(x => new brandDto()
            {
                id = x.ID,
                Name = x.Name,
            }).ToList();
            return mappedBrands;
        }

        public  brandDto getProductById(int id)
        {
            var brand = _brand.getBrandById(id);
            var mappedBrand = new brandDto()
            {
                id = brand.ID,
                Name = brand.Name,
            };
            return mappedBrand;
        }

        public  void deleteBrand(int id)
        {
            var product =  _brand.getBrandById(id);

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
