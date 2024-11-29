using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.DTO;
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

        public  void addType(typeDto type)
        {
            prodType typeUpload = new prodType()
            {
                Name = type.typeNameDto
            };
             _type.addType(typeUpload);

        }

        public void deleteType(int ?id)
        {
            var type =  _type.getTypeById(id);
            _type.deleteType(type);
        }

        public  IReadOnlyList<typeDto> getAllType()
        {
            var types = _type.getAllTypes();
            var mappedType = types.Select(x=>new typeDto()
            {
                typeNameDto=x.Name,
                typeDtoID=x.ID
            }).ToList();
            return mappedType;
        }

        public typeDto getTypeById(int? id)
        {
            var type =  _type.getTypeById(id);
            typeDto typeMapped = new typeDto()
            {
                typeNameDto = type.Name,
                typeDtoID = type.ID
            };
            return typeMapped;
        }

        public void updateType(int ?id,typeDto typDtoUpload)
        {
            var type = _type.getTypeById(id);
            type.Name = typDtoUpload.typeNameDto;
            _type.updateType(type);
        }
    }
}
