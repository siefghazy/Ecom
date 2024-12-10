using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.repos
{
    public class UserRepo : Iuser
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly StoreDbContext _Context;
        private readonly ILogger<UserRepo> _logger;

        public UserRepo(UserManager<ApplicationUser>userManager,SignInManager<ApplicationUser>signInManager,StoreDbContext context,ILogger<UserRepo>logger)
        {
            _signInManager = signInManager;
            _userManger = userManager;
            _Context = context;
            _logger = logger;
        }
        public async Task<string> register(ApplicationUser user,string password,string Role)
        {

            var res = await _userManger.CreateAsync(user, password);
            if (res.Succeeded)
            {
                await _userManger.AddToRoleAsync(user, Role);
                var addedUser = await _userManger.FindByEmailAsync(user.Email);
                var userID = addedUser.Id;
                return userID;
            }
            else
            {
                foreach (var err in res.Errors)
                {
                    _logger.LogError(err.Description);
                }
            }
            return null;
        }

        public async Task deleteUserAsync(string id)
        {
            var user = await _userManger.FindByIdAsync(id);
            await _userManger.DeleteAsync(user);
        }

        public async Task<IReadOnlyList<ApplicationUser>> getAllUserAsync()
        {
            return await _Context.Users.Include(x=>x.image).ToListAsync();
        }

        public async Task<ApplicationUser> getUserByIdAsync(string id)
        {
            var user = await _Context.Users.Include(x => x.image).FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task updateUserAsync(ApplicationUser user)
        {
            await _userManger.UpdateAsync(user);
        }

        public async Task<bool> signIn(ApplicationUser user,string password)
        {
            var userGet = await _userManger.FindByEmailAsync(user.Email);
            var checkPassword = await _userManger.CheckPasswordAsync(userGet, password);
            if (userGet is not null && checkPassword != false)
            {
                var res = await _signInManager.PasswordSignInAsync(userGet, password, false, false);

                if (res.Succeeded)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }
    }
}
