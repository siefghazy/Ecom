using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface IGeneric<Tentity,Tkey> where Tentity : BaseEntity<Tkey>
    {
        public  Task<IReadOnlyList<Tentity>> GetAllAsync();
        public Task addAsync(Tentity entity);
        public void remove(Tentity entity);
        public Task<Tentity> getByIdAsync(Tkey? id);
        public void update(Tentity entity);

    }
}
