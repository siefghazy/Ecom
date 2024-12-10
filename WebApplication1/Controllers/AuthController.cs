using ECOMMERECE.Attributes;
using ECOMMERECE.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Services.DTO;
using Store.Services.interfaces;
using System.Text.Json;

namespace ECOMMERECE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenServices _tokenServices;
        public AuthController(IUserService userService,ITokenServices token)
        {
            _userService = userService;
            _tokenServices = token;
        }
        [HttpPost]
        [checkEmail]
        public async Task signUp([FromForm] UserSignUpDto userDTO,string role)
        {
            await _userService.register(userDTO,role);
        }
        [HttpPost]
        [assignToken]
        public async Task<ActionResult> signIn([FromBody] UserSignInDto userDTO)
        {

            if (await _userService.signIn(userDTO))
            {
                return Ok();
            }
            return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest,"wrong credentials"));
        }
    }
}
