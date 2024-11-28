using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Services.DTO
{
    public  class BrandDto
    {
        public int? brandDtoId { get; set; }
        public string? Name { get; set; }
        public List<dynamic> products { get; set; }
        public string? imageUrl { get; set; }
        [JsonIgnore]
        public IFormFile? formImage { get; set; }
    }
}
