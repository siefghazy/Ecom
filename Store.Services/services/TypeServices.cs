using Store.Data.Models;
using Store.Repo.interfaces;
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

        public  void addType(prodType typ)
        {
            prodType type = new prodType()
            {
                Name = typ.Name
            };
             _type.addType(type);

        }

        public void deleteType(int ?id)
        {
            var type =  _type.getTypeById(id);
            _type.deleteType(type);
        }

        public  IReadOnlyList<prodType> getAllType()
        {
            var types =  _type.getAllTypes();
            return types;
        }

        public prodType getTypeById(int? id)
        {
            var type =  _type.getTypeById(id);
            return type;
        }

        public void updateType(int ?id,prodType typDto)
        {
            var type = _type.getTypeById(id);
            type.Name = typDto.Name;
            _type.updateType(type);
        }

    }
}
