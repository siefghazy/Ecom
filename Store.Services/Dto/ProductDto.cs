using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Store.Services.Dto
{
    public class ProductDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int brandId { get; set; }
        public int TypeId { get; set; }
        public ICollection<IFormFile> FormImages { get; set; }
        public DateTime createdAt { get; set; } 
    }
}
