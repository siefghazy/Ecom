using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Services.DTO
{
    public class UserSignUpDto
    {
        [Required(ErrorMessage = "it's a must")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "it's a must")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "it's a must")]
        public string mobilePhone { get; set; }
        [Required(ErrorMessage = "it's a must")]
        [JsonIgnore]
        public string password { get; set; }
        [Required(ErrorMessage = "it's a must")]
        public string Email { get; set; }
        [Required(ErrorMessage = "it's a must")]
        public string address { get; set; }
        public string? userName { get; set; }
        public int? userImageID { get; set; }
        public string ? userImageUrl { get; set; }
        public IFormFile? formImages { get; set; }
    }
}
