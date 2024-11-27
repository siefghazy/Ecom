using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class imagesOnProduct
    {
        [JsonIgnore]
        public int? productID { get; set; }
        public image image { get; set; }
        [JsonIgnore]
        public int ?ImageID { get; set; }
    }
}
