using ECOMMERECE.helper;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.Dto;
using Store.Services.interfaces;
using Store.Services.middlewares;
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
        private readonly IImages _Image;
        public BrandServices(Ibrand brand,IImages image)
        {
            _brand = brand;
            _Image = image;
        }

        public  void  addBrand(brandDto brandDto)
        {
            var imagePath = documentSetting.uploadFile(brandDto.FormImage, "images");
            var brandImage=ImageUploadMiddleware.imageUpload(imagePath, _Image);
            prodBrand brand = new prodBrand()
            {
                Name = brandDto.Name,
                imageId=brandImage.ID,

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
            var brands = _brand.getAllBrands();
            var mappedBrands = brands.Select(x => new brandDto()
            {
                id = x.ID,
                Name = x.Name,
                imageUrl=(string)x.image.path,
                ImageId=(int)x.image.ID,
            }).ToList();
            return mappedBrands;
        }

        public  brandDto getProductById(int id)
        {
            var brand = _brand.getBrandById(id);
            var mappedBrand = new brandDto()
            {
                id=brand.ID,
                Name = brand.Name,
                imageUrl=brand.image.path,
                ImageId=brand.image.ID,
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
                Name = brandDto.Name,
            };
           _brand.updateBrand(brand);
        }

    }
}
