using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Models
{
     public class ApplicationUser:IdentityUser
    {
        public bool? isDeleted { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public bool? isActive { get; set; }
        public image image { get; set; }
        public int? imageID { get; set; }
        [NotMapped]
        public string password { get; set; }
        public string address { get; set; }
    }
}
