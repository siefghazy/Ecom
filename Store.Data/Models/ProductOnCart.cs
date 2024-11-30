using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class ProductOnCart
    {
        public product product { get; set; }
        public int productID { get; set; }
        public Cart  cart { get; set; }
        public int cartID  { get; set; }
    }
}
