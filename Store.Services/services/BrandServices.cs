using ECOMMERECE.helper;
using Store.Data.Models;
using Store.Repo.interfaces;
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

        public  void  addBrand(prodBrand brand)
        {
            if (brand.FormImage is not null)
            {
                var imagePath = documentSetting.uploadFile(brand.FormImage, "images");
                var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                prodBrand newBrand = new prodBrand()
                {
                    Name = brand.Name,
                    imageId = brandImage.ID,

                };
                _brand.addBrand(brand);
            }
        }

        public  IReadOnlyList<prodBrand> getAllBrands()
        {
            var brands = _brand.getAllBrands();

            return brands;
        }

        public  prodBrand getProductById(int ?id)
        {
            var brand = _brand.getBrandById(id);
            return brand;
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

        public  void updateBrand(int ?id,prodBrand brandToBeUpdated)
        {
            if (brandToBeUpdated.FormImage is not null && brandToBeUpdated.Name is not null)
            {
                var brand = _brand.getBrandById(id);
                var image = _Image.getImageById(brand.imageId);
                if (image is null)
                {
                    var imagePath = documentSetting.uploadFile(brandToBeUpdated.FormImage, "images");
                    var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                    brand.imageId = brandImage.ID;
                    brand.Name = brandToBeUpdated.Name;
                    _brand.updateBrand(brand);
                }
                else
                {
                    var imagePath = documentSetting.uploadFile(brandToBeUpdated.FormImage, "images");
                    image.path = imagePath;
                    brand.Name = brandToBeUpdated.Name;
                    _Image.updateImage(image);
                    _brand.updateBrand(brand);
                }

            }
            if (brandToBeUpdated.FormImage is null || brandToBeUpdated.Name is null)
            {
                if (brandToBeUpdated.FormImage is null)
                {
                    var brand = _brand.getBrandById(id);
                    brand.Name = brandToBeUpdated.Name;
                    _brand.updateBrand(brand);
                }
                else
                {
                    var brand = _brand.getBrandById(id);
                    var image = _Image.getImageById(brand.imageId);
                    if (image is null)
                    {
                        var imagePath = documentSetting.uploadFile(brandToBeUpdated.FormImage, "images");
                        var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                        brand.imageId = brandImage.ID;
                        _brand.updateBrand(brand);
                    }
                    else
                    {
                        var imagePath = documentSetting.uploadFile(brandToBeUpdated.FormImage, "images");
                        image.path = imagePath;
                        _Image.updateImage(image);
                    }
                }

            }
        }

    }
}
