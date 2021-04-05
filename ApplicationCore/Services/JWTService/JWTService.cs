using Domain.Aggregates.UserAgg;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApplicationCore.Services.JWTService
{
    public class JWTService : IJWTService
    {
        private readonly SymmetricSecurityKey _key;
        public JWTService(IConfiguration config)
        {
           
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string GenerateJWTToken(User user)
        {
            var claims = new List<Claim>();
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
                new Claim(ClaimTypes.Name, user.UserName);
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
