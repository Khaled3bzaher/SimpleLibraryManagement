using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Application.Helpers
{
    public static class AuthenticationHelper
    {
        public static string GenerateJwtToken(IdentityUser user, string role, IConfiguration configuration)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["JwtConfig:Secret"]);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"],
                audience: configuration["JwtConfig:Audience"],
                claims:
                [
                    new Claim("id",user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role,role),
                ],
                expires: DateTime.Now.AddHours(1),
                 signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );

            return jwtTokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
