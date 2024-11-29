
using Store.Data.Models;
using Store.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface ITypeService
    {
        public IReadOnlyList<typeDto> getAllType();
        public void addType(typeDto typ);
        public typeDto getTypeById(int? id);
        public void updateType(int ? id,typeDto typDto);
        public void deleteType(int? id);
    }
}
