using CloudinaryDotNet.Actions;
using ECOMMERECE.helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.DTO;
using Store.Services.interfaces;
using Store.Services.middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.services
{
    public class productServices: IProductService
    { 
        private readonly IProduct _product;
        private readonly IImages _images;
        private readonly Ibrand _brand;
        private readonly IType _type;
        private readonly IimagesOnProduct _imageOnProduct;
        private readonly IVariance _variance;
        private readonly ILoggerFactory _loggerFactory;

        public productServices(IProduct product,IImages images,Ibrand brand,IType type,IimagesOnProduct iimagesOnProduct,ILoggerFactory loggerFactory,IVariance variance)
        {
            _product = product;
            _images = images;
            _brand = brand;
            _type = type;
            _imageOnProduct = iimagesOnProduct;
            _loggerFactory = loggerFactory;
            _variance = variance;
        }


        public async Task<IReadOnlyList<productDTO>> getAllProducts()
        {
            try
            {
                var products = await _product.getAllProducts();
                var mappedProduct = products.Select(p => new productDTO()
                {
                    productDtoID = p.ID,
                    name = p.Name,
                    description = p.description,
                    price = p.price,
                    productBrandDtoID = p.prodBrand?.ID,
                    productBrandDtoName = p.prodBrand?.Name,
                    productBrandDtoImageUrl = p.prodBrand?.image?.path,
                    productTypeDtoId = p.prodType?.ID,
                    productTypeDtoName = p.prodType?.Name,
                    productDtoImageUrl = p.productImages?.Select(i => (dynamic)new { imageID = i.image.ID, path = i.image.path }).ToList()
                });
                return mappedProduct.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public  productDTO getProductById(int id)
        {
            var product = _product.getPrdouctById(id);
            var producImages = product.productImages?.Select(i => (dynamic)new 
            {
                path=i.image?.path,
                imageId=i.image?.ID
            }).ToList();
            productDTO productToBeMapped = new productDTO()
            {
                name = product.Name,
                description=product.description,
                price = product.price,
                productDtoID = product.ID,
                productBrandDtoID=product.prodBrand?.ID,                
                productBrandDtoName=product.prodBrand?.Name,
                productBrandDtoImageUrl=product.prodBrand?.image?.path,
                productTypeDtoId=product.prodType?.ID,
                productTypeDtoName=product.prodType?.Name,
                productDtoImageUrl=producImages
            };
            return productToBeMapped;
        }

        public  void deleteProduct(int id)
        {
            var product = _product.getPrdouctById(id);
            if (product.productImages.Count==0)
            {
                _product.removeProduct(product);
            }
           else
            {
                _product.removeProduct(product);
                foreach (var image in product.productImages)
                {
                    _images.removeImage(image.ImageID);
                }
            }

        }

        public  void updateProduct(product product)
        {
            product updateProduct = new product()
            {
                ID = product.ID,
                description = product.description,
                Name = product.Name,
                brandID = product.brandID,
                typID = product.typID,
                price = product.price,
                CreatedAt = (DateTime)product.CreatedAt
            };
            _product.updateProduct(updateProduct);
        }

        public  void addProduct(productDTO productDTO)
        {
                var brandGet = _brand.getAllBrands().FirstOrDefault(b => b.Name == productDTO.productBrandDtoName);
                var typGet = _type.getAllTypes().FirstOrDefault(x => x.Name == productDTO.productTypeDtoName);
                product product1 = new product()
                {
                    description = productDTO.description,
                    price = productDTO.price,
                    brandID = brandGet.ID,
                    typID = typGet.ID,
                    CreatedAt = DateTime.Now,
                    Name = productDTO.name,
                };
                if (productDTO.formImages is null)
                {
                    _product.addProduct(product1);
                }
                else
                {
                    var productAdded = _product.addProductGet(product1);
                    foreach (IFormFile file in productDTO.formImages)
                    {
                        var path = documentSetting.uploadFile(file, "images");
                        var uploadedImage = ImageUploadMiddleware.imageUpload(path, _images);
                        var imageOnProduct = new imagesOnProduct()
                        {
                            productID = productAdded.ID,
                            ImageID = uploadedImage.ID
                        };
                        _imageOnProduct.addOnImageOnProduct(imageOnProduct);
                    }
                }
               
        }

        public async Task addVarianceAsync(varianceAddDTO variance)
        {
            ProductVariance productVariance = new ProductVariance()
            {
                productID = variance.productIdDTO,
                colorCode = variance.colorCode,
                quanitity = variance.quantity
            };
            await _variance.addProductVarianceAsync(productVariance);
        }

       public async  Task<VarianceGetDTO> VarianceGet(int id)
        {
            var products = await _variance.GetProductVarianceByIdAsync(id);
            List<dynamic> variances = new List<dynamic>();
            List<dynamic>productImage = new List<dynamic>();
            for (int i = 0; i < products.Count; i++)
            {
                var varianceObject = new
                {
                    colorCode = products[i].colorCode,
                    quantity = products[i].quanitity
                };
                variances.Add(varianceObject);
            }
            foreach (var I in products[0].product.productImages)
            {
                var imageObject = new
                {
                    imageID = I.image.ID,
                    path = I.image.path
                };
                productImage.Add(imageObject);
            }
            VarianceGetDTO productGet = new VarianceGetDTO()
            {
                productId = products[0].product.ID,
                productName = products[0].product.Name,
                productDescribtion = products[0].product.description,
                productImages = productImage,
                productBrandId = products[0].product.prodBrand.ID,
                productBrandName = products[0].product.prodBrand.Name,
                productBrandImageId = products[0].product.prodBrand.image?.ID,
                productBrandImage= products[0].product.prodBrand.image?.path,
                productTypeId= products[0].product.prodType.ID,
                productTypeName= products[0].product.prodType.Name,
                variances = variances
            };
            return productGet;
        }

        void IProductService.updateVariance(int id, varianceAddDTO variance)
        {
            throw new NotImplementedException();
        }
    }
}
