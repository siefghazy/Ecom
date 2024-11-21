using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class image:BaseEntity<int>
    {
        public string path { get; set; }
        public prodBrand prodBrand { get; set; }
        public ICollection<product> products { get; set; }
    }
}
