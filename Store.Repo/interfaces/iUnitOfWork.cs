using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface iUnitOfWork
    {
        public Task saveChangesAsync();
        IGeneric<Tentity,Tkey> repostries<Tentity,Tkey>() where Tentity : BaseEntity<Tkey>;
    }
}
