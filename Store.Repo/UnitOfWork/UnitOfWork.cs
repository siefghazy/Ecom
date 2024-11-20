using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Repo.repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.UnitOfWork
{
    public class UnitOfWork : iUnitOfWork
    {
        private Hashtable _reposetries;
        private readonly StoreDbContext _context;
        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public IGeneric<Tentity, Tkey> repostries<Tentity, Tkey>() where Tentity : BaseEntity<Tkey>
        {
            if (_reposetries == null)
            {
                _reposetries = new Hashtable();
            }
            var entityKey=typeof(Tentity).Name;
            if (!_reposetries.ContainsKey(entityKey))
            {
                var entityType = typeof(genericRepo<,>); //genericRepo<>
                var objectInstance = Activator.CreateInstance(entityType.MakeGenericType(typeof(Tentity), typeof(Tkey)), _context);//genericRepo<Tentity,Tkey>(_context)
                _reposetries.Add(entityKey, objectInstance);
            }
            return (IGeneric<Tentity, Tkey>)_reposetries[entityKey];
        }

        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
