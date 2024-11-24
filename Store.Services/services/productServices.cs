using CloudinaryDotNet.Actions;
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
    public class productServices: IProductService
    { 
        private readonly IProduct _product;
        private readonly IImages _images;
        public productServices(IProduct product,IImages images)
        {
            _product = product;
            _images = images;
        }


        public IReadOnlyList<product> getAllProducts()
        {
            var products = _product.getAllProducts();
            return products;
        }


        public  product getProductById(int id)
        {
            var product =  _product.getPrdouctById(id);
            return product;
        }

        public  void deleteProduct(int id)
        {
            var product =  _product.getPrdouctById(id);
            _product.removeProduct(product);
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
                CreatedAt = (DateTime)product.CreatedAt,
               // ImageUrl = product.imageUrl,
            };
            _product.updateProduct(updateProduct);
        }

        public  void addProduct(product product)
        {
            product mappedProduct = new product()
            {
                ID =product.ID,
                description = product.description,
                price = product.price,
                brandID = product.brandID,
                typID = product.typID,
                CreatedAt = (DateTime)product.CreatedAt,
                Name = product.Name,
                //ImageUrl = productDto.imageUrl
            };
             _product.addProduct(mappedProduct);
        }
    }
}
