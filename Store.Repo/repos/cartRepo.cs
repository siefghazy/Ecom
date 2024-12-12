using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.repos
{
    public class cartRepo : Icart
    {
        private readonly StoreDbContext _Context;

        public cartRepo(StoreDbContext context)
        {
            _Context = context;
        }

        public async Task<Cart> creatCartGetAsync(Cart cart)
        {
            Cart cartAdd = new Cart()
            {
                userID = cart.userID,
            };
            await _Context.carts.AddAsync(cartAdd);
            await _Context.SaveChangesAsync();
            return cartAdd;
        }

        public void removeCartAsync(Cart cart)
        {
            _Context.carts.Remove(cart);
        }
        public async Task createCartAsync(Cart cart)
        {
            await _Context.carts.AddAsync(cart);
            await _Context.SaveChangesAsync();
        }

       public async Task<Cart> GetUserCartByIdAsync(string userID)
        {
            return await _Context.carts.FirstOrDefaultAsync(x => userID == userID);
        }
    }
}
