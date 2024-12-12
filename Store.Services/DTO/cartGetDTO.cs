using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.DTO
{
    public class cartGetDTO
    {
        
        public int cartID { get; set; }
        public List<dynamic> products { get; set; }
    }
}
