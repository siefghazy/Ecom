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

        public  void addType(typDto typDto)
        {
            prodType type = new prodType()
            {
                Name = typDto.Name
            };
             _type.addType(type);

        }

        public void deleteType(int ?id)
        {
            var type =  _type.getTypeById(id);
            _type.deleteType(type);
        }

        public  IReadOnlyList<typDto> getAllType()
        {
            var types =  _type.getAllTypes();
            var mappedTypes = types.Select(x => new typDto
            {
                id = x.ID,
                Name = x.Name,
            }).ToList();
            return mappedTypes;
        }

        public typDto getTypeById(int? id)
        {
            var type =  _type.getTypeById(id);
            var mappedType = new typDto
            {
                id = type.ID,
                Name = type.Name,
            };
            return mappedType;
        }

        public void updateType(int ?id,typDto typDto)
        {
            prodType type = new prodType
            {
                Name = typDto.Name,
            };
            _type.updateType(type);
        }

    }
}
