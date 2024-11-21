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
    public class TypeServices : ITypeService
    {
        private readonly iUnitOfWork _unitOfWork;
        public TypeServices(iUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        public async void addType(typDto typDto)
        {
            prodType type = new prodType()
            {
                ID = typDto.id,
                Name = typDto.Name
            };
            await _unitOfWork.repostries<prodType, int>().addAsync(type);

        }

        public async void deleteType(int id)
        {
            var type = await _unitOfWork.repostries<prodType, int>().getByIdAsync(id);
            _unitOfWork.repostries<prodType, int>().remove(type);
        }

        public async Task<IReadOnlyList<typDto>> getAllTypeAsync()
        {
            var types = await _unitOfWork.repostries<prodType, int>().GetAllAsync();
            var mappedTypes = types.Select(x => new typDto
            {
                id = x.ID,
                Name = x.Name,
            }).ToList();
            return mappedTypes;
        }

        public async Task<typDto> getTypeById(int id)
        {
            var type = await _unitOfWork.repostries<prodType, int>().getByIdAsync(id);
            var mappedType = new typDto
            {
                id = type.ID,
                Name = type.Name,
            };
            return mappedType;
        }

        public void updateType(typDto typDto)
        {
            prodType type = new prodType
            {
                ID = typDto.id,
                Name = typDto.Name,
            };
            _unitOfWork.repostries<prodType, int>().remove(type);
        }
    }
}
