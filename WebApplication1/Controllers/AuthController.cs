using ECOMMERECE.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.DTO;
using Store.Services.interfaces;

namespace ECOMMERECE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        AuthController(IUserService userService,UserManager<ApplicationUser>_userManager)
        {
            _userService = userService;
        }
        [HttpPost]
       [checkEmail]
        public void signUp(UserSignUpDto userDTO)
        {
            _userService.register(userDTO);

        }
    }
}
