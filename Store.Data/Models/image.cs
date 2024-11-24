using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class image:BaseEntity<int>
    {
        public string path { get; set; }
        [JsonIgnore]
        public prodBrand prodBrand { get; set; }
        [JsonIgnore]
        public product products { get; set; }
        public  int? productID { get; set; }
    }
}
