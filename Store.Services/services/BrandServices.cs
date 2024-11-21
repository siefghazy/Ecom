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
        private readonly iUnitOfWork _unitOfWork;
        public BrandServices(iUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        public async void  addBrand(brandDto brandDto)
        {
            prodBrand brand = new prodBrand()
            {
                ID = brandDto.id,
                Name = brandDto.Name,
            };
            await _unitOfWork.repostries<prodBrand, int>().addAsync(brand);
            await _unitOfWork.saveChangesAsync();
        }

        public async void deleteProduct(int id)
        {
            var product = await _unitOfWork.repostries<prodBrand, int>().getByIdAsync(id);
            _unitOfWork.repostries<prodBrand, int>().remove(product);
            await _unitOfWork.saveChangesAsync();
        }

        public async Task<IReadOnlyList<brandDto>> getAllBrandsAsync()
        {
            var brands = await _unitOfWork.repostries<prodBrand, int>().GetAllAsync();
            var mappedBrands = brands.Select(x => new brandDto()
            {
                id = x.ID,
                Name = x.Name,
            }).ToList();
            return mappedBrands;
        }

        public async Task<brandDto> getProductById(int id)
        {
            var brand = await _unitOfWork.repostries<prodBrand, int>().getByIdAsync(id);
            var mappedBrand = new brandDto()
            {
                id = brand.ID,
                Name = brand.Name,
            };
            return mappedBrand;
        }

        public async void deleteBrand(int id)
        {
            var product = await _unitOfWork.repostries<prodBrand, int>().getByIdAsync(id);
            _unitOfWork.repostries<prodBrand,int>().remove(product);
        }

        public async void updateBrand(brandDto brandDto)
        {
            prodBrand brand = new prodBrand
            {
                ID = brandDto.id,
                Name = brandDto.Name,
            };
            _unitOfWork.repostries<prodBrand, int>().remove(brand);
            await _unitOfWork.saveChangesAsync();
        }
    }
}
