using LaurelManagement.Business.Abstract;
using LaurelManagement.Config;
using LaurelManagement.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LaurelManagement.Business.Services
{
   public class TokenManager:ITokenService
    {
        private readonly JwtConfig _jwtConfig;
        public TokenManager(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateToken(User user)
        {
            var Claims = new Claim[]
            {
                new Claim("id",user.Id.ToString()),
                new Claim("email",user.Email),
                new Claim("phone",user.Phone)
            };
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Issuer,
                claims: Claims,
                expires: DateTime.Now.AddMinutes(_jwtConfig.Expires),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
