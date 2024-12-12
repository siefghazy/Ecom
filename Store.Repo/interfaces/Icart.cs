using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface Icart
    {
        public Task<Cart> creatCartGetAsync(Cart cart);
        public void removeCartAsync(Cart cart);
        public Task createCartAsync(Cart cart);
        public Task<Cart> GetUserCartByIdAsync(string userID);
    }
}
