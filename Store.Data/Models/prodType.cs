using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class prodType:BaseEntity<int>
    {
        [JsonIgnore]
        public ICollection<product> product { get; set; }
        public string Name { get; set; }
    }
}
