using Microsoft.AspNetCore.Http;
using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Services.DTO
{
    public class productDTO
    {
        public int ?productDtoID { get; set; }
        public string ?name { get; set; }
        public string  ?description { get; set; }
        public decimal ?price { get; set; }
        public int ?productBrandDtoID { get; set; }
        public string ?productBrandDtoName { get; set; }
        public string? productBrandDtoImageUrl { get; set; }
        public int ?productTypeDtoId { get; set; }
        public string  productTypeDtoName { get; set; }
        public List<dynamic> ?productDtoImageUrl { get; set; }
        [JsonIgnore]
        public ICollection<IFormFile>? formImages { get; set; }
    }
}
