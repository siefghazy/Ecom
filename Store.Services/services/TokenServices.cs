using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Models;
using Store.Services.interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> createTokenAsync(ApplicationUser user,UserManager<ApplicationUser>userManager)
        {
            var authClaims = new List<Claim>()
            { 
                new Claim(ClaimTypes.UserData,$"{user.Id}")
            };
            var userRole = await userManager.GetRolesAsync(user);
            var key = _configuration["jwt:key"];
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            foreach (var role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = new JwtSecurityToken(issuer: _configuration["jwt:issuer"], claims: authClaims, expires: DateTime.Now.AddDays(double.Parse(_configuration["jwt:DurationInDays"])), signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
