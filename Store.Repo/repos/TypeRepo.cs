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

        public void  addType(prodType prodType)
        {
             _Context.Add(prodType);
            _Context.SaveChanges();
        }

        public IReadOnlyList<prodType> getAllTypes()
        {
            return _Context.ProdTypes.ToList();
        }

        public prodType getTypeById(int ?id)
        {
            return  _Context.ProdTypes.Find(id);
        }

        public void updateType(prodType productType)
        {
            _Context.ProdTypes.Update(productType);
            _Context.SaveChanges();
        }

        public void deleteType(prodType prodType)
        {
            _Context.ProdTypes.Remove(prodType);
            _Context.SaveChanges();
        }
    }
}
