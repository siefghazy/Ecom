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
    public class TypeRepo:IType
    {
        private readonly StoreDbContext _Context;
        public TypeRepo(StoreDbContext context)
        {
            _Context = context;
        }

        public async Task addTypeAsync(prodType prodType)
        {
            await _Context.AddAsync(prodType);
            _Context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<prodType>> getAllTypesAsync()
        {
            return await _Context.ProdTypes.ToListAsync();
        }

        public async Task<prodType> getTypeById(int id)
        {
            return await _Context.ProdTypes.FindAsync(id);
        }

        public void updateType(prodType productType)
        {
            _Context.Update(productType);
            _Context.SaveChanges();
        }

        public void deleteType(prodType prodType)
        {
            _Context.ProdTypes.Remove(prodType);
            _Context.SaveChanges();
        }
    }
}
