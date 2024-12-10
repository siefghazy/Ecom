using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface Iuser
    {
        public Task<IReadOnlyList<ApplicationUser>> getAllUserAsync();
        public Task<ApplicationUser> getUserByIdAsync(string id);
        public Task updateUserAsync(ApplicationUser user);
        public Task<string> register(ApplicationUser user,string password,string role);
        public Task deleteUserAsync(string id);
        public Task<bool> signIn(ApplicationUser user,string password);

    }
}
