using Microsoft.AspNetCore.Http;
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
        public decimal? price { get; set; }
        public prodType prodType { get; set; }
        public int? typID { get; set; }
        [JsonIgnore]
        public  prodBrand prodBrand { get; set; }

        public int? brandID { get; set; }
        public ICollection<imagesOnProduct>? productImages { get; set; }
        [JsonIgnore]
        [NotMapped]
        public ICollection<IFormFile> formImages { get; set; }
        [JsonIgnore]
        public ICollection<ProductOnCart> productOnCarts { get; set; }
    }
}
