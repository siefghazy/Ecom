using Store.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface ITypeService
    {
        public IReadOnlyList<typDto> getAllType();
        public void addType(typDto typDto);
        public typDto getTypeById(int id);
        public void updateType(typDto typDto);
        public void deleteType(int id);
    }
}
