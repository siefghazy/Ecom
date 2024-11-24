using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class product:BaseEntity<int>
    {
        public string Name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        [JsonIgnore]
        public prodType prodType { get; set; }
        public int? typID { get; set; }
        [JsonIgnore]
        public prodBrand prodBrand{ get; set; }
        public int ?brandID { get; set; }
        public ICollection<image> ?productImages { get; set; }
    }
}
