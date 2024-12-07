using Microsoft.AspNetCore.Identity;
using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.interfaces
{
    public interface ITokenServices
    {
        public Task<string> createTokenAsync(ApplicationUser user,UserManager<ApplicationUser>userManager);

    }
}
