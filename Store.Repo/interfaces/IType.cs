using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface IType
    {
        public IReadOnlyList<prodType> getAllTypes();
        public prodType getTypeById(int ?id);
        public void addType(prodType prodType);
        public void updateType(prodType prodType);
        public void deleteType(prodType prodType);

    }
}
