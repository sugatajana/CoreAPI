using CoreAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _config;
        DateTime IndianDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

        public JWTService(IConfiguration config)
        {
            _config = config;
        }
        public Token Authenticate(User user)
        {
            if (user.userName.Equals("admin") && user.password.Equals("123456"))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("userName", user.userName),
                    new Claim("password", user.password)
                }),
                    Expires = IndianDateTime.AddSeconds(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Token { token = tokenHandler.WriteToken(token) };
            }
            else
            {
                return null;
            }
        }
    }
}
