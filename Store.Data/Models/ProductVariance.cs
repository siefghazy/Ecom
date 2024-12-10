using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class ProductVariance:BaseEntity<int>
    {
        public product product { get; set; }
        public int productID { get; set; }
        public string colorCode { get; set; }
        public int quanitity { get; set; }
    }
}
