using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.repos
{
    public class genericRepo<Tentity, Tkey> : IGeneric<Tentity, Tkey> where Tentity : BaseEntity<Tkey>
    {
        private readonly StoreDbContext _context;

        public genericRepo(StoreDbContext context)
        {
            _context = context;
        }

        public async Task addAsync(Tentity entity)
        {
            await _context.Set<Tentity>().AddAsync(entity);
        }

        public async Task<IReadOnlyList<Tentity>> GetAllAsync()
        {
          return await _context.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity> getByIdAsync(Tkey? id)
        {
            return await _context.Set<Tentity>().FindAsync(id);
        }

        public  void remove(Tentity entity)
        {
           _context.Set<Tentity>().Remove(entity);
        }

        public void update(Tentity entity)
        {
            _context.Set<Tentity>().Update(entity);
        }
    }
}
