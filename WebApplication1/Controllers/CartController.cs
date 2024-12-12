using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Store.Services.DTO;
using Store.Services.interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;
namespace ECOMMERECE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IcartServices _cartServices;

        public CartController(IcartServices cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpPost]
        [Authorize]
        public async Task addcart([FromBody]cartAddDto cart)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            if (token.StartsWith("Bearer"))
            {
                token = token.Substring(7);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var userID = jwtToken.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata").Value;
            await _cartServices.addCartAsync(userID, cart);
        }
     }
    }
