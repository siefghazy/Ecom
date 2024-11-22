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
    public class productServices:IProductService
    {
        private readonly IProduct _product;
        public productServices(IProduct product)
        {
            _product = product;
        }


        public async Task<IReadOnlyList<ProductDto>> getAllProductsAsync()
        {
            var products = await _product.getAllProductsAsync();
            var mappedProducts = products.Select(x => new ProductDto()
            {
                id = x.ID,
                Name = x.Name,
                description = x.description,
                brandId = x.brandID,
                TypeId = x.typID,
                price = x.price,
                createdAt = (DateTime)x.CreatedAt,
            }).ToList();
            return mappedProducts;
        }


        public async Task<ProductDto> getProductById(int id)
        {
            var product = await _product.getPrdouctById(id);
            var mappenProduct = new ProductDto()
            {
                id = product.ID,
                description = product.description,
                Name = product.Name,
                 brandId = product.brandID,
                TypeId = product.typID,
                price = product.price,
                createdAt = (DateTime)product.CreatedAt
            };
            return mappenProduct;
        }

        public async void deleteProduct(int id)
        {
            var product = await _product.getPrdouctById(id);
            _product.removeProduct(product);
        }

        public  void updateProduct(ProductDto product)
        {
            product updateProduct = new product()
            {
                ID = product.id,
                description = product.description,
                Name = product.Name,
                brandID = product.brandId,
                typID = product.TypeId,
                price = product.price,
                CreatedAt = (DateTime)product.createdAt,
                ImageUrl = product.imageUrl,
            };
            _product.updateProduct(updateProduct);
        }

        public async void addProduct(ProductDto productDto)
        {
            product mappedProduct = new product()
            {
                ID = productDto.id,
                description = productDto.description,
                price = productDto.price,
                brandID = productDto.brandId,
                typID = productDto.TypeId,
                CreatedAt = (DateTime)productDto.createdAt,
                Name = productDto.Name,
                ImageUrl = productDto.imageUrl
            };
            await _product.addProductAsync(mappedProduct);
        }
    }
}
