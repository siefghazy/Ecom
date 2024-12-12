using Store.Data.Models;
using Store.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface IcartServices
    {
        public Task addCartAsync(string userID,cartAddDto cartDTO);
        public void removeCartGetAsync(string userID,int id);
        public Task updateProudctCart(string userID, cartAddDto cartDTO);
    }
}
