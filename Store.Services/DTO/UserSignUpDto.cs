using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Services.DTO
{
    public class UserSignUpDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobilePhone { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public string Email { get; set; }
        public string address { get; set; }
        public string? userName { get; set; }
        public int? userImageID { get; set; }
        public string ? userImageUrl { get; set; }
        public FormFile? formImages { get; set; }
    }
}
