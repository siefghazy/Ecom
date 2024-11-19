using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class product:BaseEntity<int>
    {
        public string Name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public string? ImageUrl { get; set; }
        public prodType prodType { get; set; }
        public int typID { get; set; }

        public prodBrand prodBrand{ get; set; }
        public int brandID { get; set; }
    }
}
