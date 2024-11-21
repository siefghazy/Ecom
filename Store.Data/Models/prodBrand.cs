using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class prodBrand :BaseEntity<int>
    {
       public  List<product> products;
        public string Name { get; set; }
        public image image { get; set; }
        public int? imageId { get; set; }
    }
}
