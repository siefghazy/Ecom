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
        private readonly IType _type;
        public TypeServices(IType type)
        {
           _type = type;
        }

        public async void addType(typDto typDto)
        {
            prodType type = new prodType()
            {
                ID = typDto.id,
                Name = typDto.Name
            };
            await _type.addTypeAsync(type);

        }

        public async void deleteType(int id)
        {
            var type = await _type.getTypeById(id);
            _type.deleteType(type);
        }

        public async Task<IReadOnlyList<typDto>> getAllTypeAsync()
        {
            var types = await _type.getAllTypesAsync();
            var mappedTypes = types.Select(x => new typDto
            {
                id = x.ID,
                Name = x.Name,
            }).ToList();
            return mappedTypes;
        }

        public async Task<typDto> getTypeById(int id)
        {
            var type = await _type.getTypeById(id);
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
            _type.updateType(type);
        }
    }
}
