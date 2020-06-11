using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserLoginApi.Models;

namespace UserLoginApi.Classes
{
    public class TokenOptions
    {
        private IConfiguration _config;

        public TokenOptions(IConfiguration configuration)
        {
            _config = configuration;
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["TokenKey"]));
        }

        public string GenerateToken(Users user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            };
            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: _config["TokenIssuer"],
                    audience: _config["TokenAudience"],
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.Add(TimeSpan.FromMinutes(double.Parse(_config["TokenLifetime"]))),
                    signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
