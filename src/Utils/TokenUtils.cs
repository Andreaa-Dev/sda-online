using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ecommerce.src.Entity;
using Microsoft.IdentityModel.Tokens;

namespace ecommerce.src.Utils
{
    public class TokenUtils
    {

        // field
        private readonly IConfiguration _config;
        // step 3:
        // inject the configuration 
        public TokenUtils(IConfiguration config)
        {
            _config = config;
        }


        // method to create/ generate token
        public string GenerateToken(User user)
        {

            // step 5: subject = list of claims
            // never put password in claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email ),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            // step 3: key
            // var key = _config.GetSection("Jwt: Key").Value!;
            // string => IdentityModel.Tokens.SecurityKey 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value!));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // use _config to access value in appsetting
            var issuer = _config.GetSection("Jwt:Issuer").Value;
            var audience = _config.GetSection("Jwt:Audience").Value;

            // step 2: descriptor
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.Now.AddMinutes(60),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials
            };

            // step 1
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}