using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Data.Models
{
    public class prodBrand :BaseEntity<int>
    {
        public string Name { get; set; }
        public image? image { get; set; }
        public int? imageId { get; set; }
        public ICollection<product> products { get; set; }
        [JsonIgnore]
        [NotMapped]
        public IFormFile? FormImage { get; set; }

    }
}
