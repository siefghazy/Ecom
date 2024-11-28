using ECOMMERECE.helper;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Repo.repos;
using Store.Services.DTO;
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

       /* public  void  addBrand(BrandDto brand)
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
        }*/

        public  IReadOnlyList<BrandDto> getAllBrands()
        {
            var brands = _brand.getAllBrands().Select(x => new BrandDto()
            {
                Name = x.Name,
                brandDtoId = x.ID,
                imageUrl = x.image?.path,
                products = x.products.Select(p => new
                {
                    productID = p.ID,
                    productName = p.Name,
                    productDescribtion = p.description,
                    productImages = p.productImages.Select(i => new
                    {
                        imageID = i.image.ID,
                        paht=i.image.path
                    })
                }).ToList<dynamic>()
            }).ToList();
            return brands;

        }

        public  BrandDto getProductById(int ?id)
        {
            var brand = _brand.getBrandById(id);
            BrandDto mappedProduct = new BrandDto()
            {
                brandDtoId= brand.ID,
                Name = brand.Name,
                imageUrl= brand.image?.path,
                products=brand.products.Select(p => new
                {
                    productID = p.ID,
                    productName = p.Name,
                    productDescribtion = p.description,
                    productImages = p.productImages.Select(i => new
                    {
                        imageID = i.image.ID,
                        paht = i.image.path
                    })
                }).ToList<dynamic>()
            };
            return mappedProduct;
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

        public  void updateBrand(int id,BrandDto brandToBeUpdated)
        {
            if (brandToBeUpdated.formImage is not null && brandToBeUpdated.Name is not null)
            {
                var brand = _brand.getBrandById(id);
                var image = _Image.getImageById(brand.imageId);
                if (image is null)
                {
                    var imagePath = documentSetting.uploadFile(brandToBeUpdated.formImage, "images");
                    var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                    brand.imageId = brandImage.ID;
                    brand.Name = brandToBeUpdated.Name;
                    _brand.updateBrand(brand);
                }
                else
                {
                    var imagePath = documentSetting.uploadFile(brandToBeUpdated.formImage, "images");
                    image.path = imagePath;
                    brand.Name = brandToBeUpdated.Name;
                    _Image.updateImage(image);
                    _brand.updateBrand(brand);
                }

            }
            if (brandToBeUpdated.formImage is null || brandToBeUpdated.Name is null)
            {
                if (brandToBeUpdated.formImage is null)
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
                        var imagePath = documentSetting.uploadFile(brandToBeUpdated.formImage, "images");
                        var brandImage = ImageUploadMiddleware.imageUpload(imagePath, _Image);
                        brand.imageId = brandImage.ID;
                        _brand.updateBrand(brand);
                    }
                    else
                    {
                        var imagePath = documentSetting.uploadFile(brandToBeUpdated.formImage, "images");
                        image.path = imagePath;
                        _Image.updateImage(image);
                    }
                }

            }
        }

    }
}
