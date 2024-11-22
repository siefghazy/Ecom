using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Dto
{
     public class brandDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public IFormFile? FormImage { get; set; }
    }
}
