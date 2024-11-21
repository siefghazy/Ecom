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
        public Task<IReadOnlyList<typDto>> getAllTypeAsync();
        public void addType(typDto typDto);
        public Task<typDto> getTypeById(int id);
        public void updateType(typDto typDto);
        public void deleteType(int id);
    }
}
