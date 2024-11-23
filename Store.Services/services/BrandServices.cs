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
            if (brandDto.FormImage is not null)
            {
                var imagePath = documentSetting.uploadFile(brandDto.FormImage, "images");
                var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                prodBrand brand = new prodBrand()
                {
                    Name = brandDto.Name,
                    imageId = brandImage.ID,

                };
                _brand.addBrand(brand);
            }
            else
            {
                prodBrand brand = new prodBrand()
                {
                    Name = brandDto.Name,

                };
                _brand.addBrand(brand);
            }

        }

        public  IReadOnlyList<brandDto> getAllBrands()
        {
            var brands = _brand.getAllBrands();
            var mappedBrands = brands.Select(x => new brandDto()
            {
                id = x?.ID,
                Name = x.Name,
                imageUrl=x.image?.path,
                ImageId=x.image?.ID,
            }).ToList();
            return mappedBrands;
        }

        public  brandDto getProductById(int id)
        {
            var brand = _brand.getBrandById(id);
            var mappedBrand = new brandDto()
            {
                id=brand?.ID,
                Name = brand?.Name,
                imageUrl=brand?.image?.path,
                ImageId=brand?.image?.ID,
            };
            return mappedBrand;
        }

        public  void deleteBrand(int? id)
        {
            var product = _brand.getBrandById(id);
            if (product.imageId is null)
            {
                _brand.deleteBrand(product);
            }
            else
            {
                ImageUploadMiddleware.deleteImageDuringRemoveBrand(product, _Image);
                _brand.deleteBrand(product);
            }
        }

        public  void updateBrand(int ?id,brandDto brandDto)
        {
            if (brandDto.FormImage is not null && brandDto.Name is not null)
            {
                var brand = _brand.getBrandById(id);
                var image = _Image.getImageById(brand.imageId);
                if (image is null)
                {
                    var imagePath = documentSetting.uploadFile(brandDto.FormImage, "images");
                    var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                    brand.imageId = brandImage.ID;
                    brand.Name = brandDto.Name;
                    _brand.updateBrand(brand);
                }
                else
                {
                    var imagePath = documentSetting.uploadFile(brandDto.FormImage, "images");
                    image.path = imagePath;
                    brand.Name = brandDto.Name;
                    _Image.updateImage(image);
                    _brand.updateBrand(brand);
                }

            }
            if (brandDto.FormImage is null || brandDto.Name is null)
            {
                if (brandDto.FormImage is null)
                {
                    var brand = _brand.getBrandById(id);
                    brand.Name = brandDto.Name;
                    _brand.updateBrand(brand);
                }
                else
                {
                    var brand = _brand.getBrandById(id);
                    var image = _Image.getImageById(brand.imageId);
                    if (image is null)
                    {
                        var imagePath = documentSetting.uploadFile(brandDto.FormImage, "images");
                        var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                        brand.imageId = brandImage.ID;
                        _brand.updateBrand(brand);
                    }
                    else
                    {
                        var imagePath = documentSetting.uploadFile(brandDto.FormImage, "images");
                        image.path = imagePath;
                        _Image.updateImage(image);
                    }
                }

            }
        }

    }
}
