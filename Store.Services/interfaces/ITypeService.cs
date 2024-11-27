
using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface ITypeService
    {
        public IReadOnlyList<prodType> getAllType();
        public void addType(prodType typ);
        public prodType getTypeById(int? id);
        public void updateType(int ? id,prodType typDto);
        public void deleteType(int? id);
    }
}
