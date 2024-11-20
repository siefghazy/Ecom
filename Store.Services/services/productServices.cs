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
        private readonly iUnitOfWork _unitOfWork;
        public productServices(iUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        public async Task<IReadOnlyList<brandDto>> getAllBrandAsync()
        {
            var brands = await _unitOfWork.repostries<prodBrand, int>().GetAllAsync();
            var mappedBrands = brands.Select(x => new brandDto()
            {
                Name = x.Name,
                id = x.ID,
            }).ToList();
            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDto>> getAllProductsAsync()
        {
            var products = await _unitOfWork.repostries<product, int>().GetAllAsync();
            var mappedProducts = products.Select(x => new ProductDto()
            {
                id = x.ID,
                Name = x.Name,
                description = x.description,
                brandName = x.prodBrand.Name,
                brandType = x.prodType.Name,
                price = x.price,
                createdAt = (DateTime)x.CreatedAt,
            }).ToList();
            return mappedProducts;
        }

        public async Task<IReadOnlyList<brandDto>> getAllTypesAsync()
        {
            var types = await _unitOfWork.repostries<prodType, int>().GetAllAsync();
            var mappedTypes = types.Select(x => new brandDto()
            {
                Name = x.Name,
                id = x.ID,
            }).ToList();
            return mappedTypes;
        }

        public async Task<ProductDto> getProductById(int id)
        {
            var product = await _unitOfWork.repostries<product, int>().getByIdAsync(id);
            var mappenProduct = new ProductDto()
            {
                id = product.ID,
                description = product.description,
                Name = product.Name,
                brandName = product.prodBrand.Name,
                brandType = product.prodType.Name,
                price = product.price,
                createdAt = (DateTime)product.CreatedAt
            };
            return mappenProduct;
        }
    }
}
