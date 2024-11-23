using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Services.Dto
{
     public class brandDto
    {
        public int? id { get; set; }
        public string? Name { get; set; }
        public string? imageUrl { get; set; }
        public int? ImageId { get; set; }
        [JsonIgnore]
        public IFormFile? FormImage { get; set; }
    }
}
