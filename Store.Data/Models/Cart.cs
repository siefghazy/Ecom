using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class Cart:BaseEntity<int>
    {
        public  ApplicationUser user{ get; set; }
        public string userID { get; set; }
        public ICollection<ProductOnCart> cartOnProduct { get; set; }
    }
}
