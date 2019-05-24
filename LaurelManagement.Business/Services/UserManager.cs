using LaurelManagement.Business.Abstract;
using LaurelManagement.Config;
using LaurelManagement.Data;
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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private readonly JwtConfig _jwtConfig;
        public UserManager(IUserDal userDal, IOptions<JwtConfig> jwtConfig)
        {
            _userDal = userDal;
            _jwtConfig = jwtConfig.Value;
        }



        public bool Add(User entity)
        {
            entity.Token = GenerateToken(entity);
            var result = _userDal.Add(entity);
            return result;
        }

        public User Authenticate(User entity)
        {
            var user = _userDal.AuthenticateUser(entity);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }


        public bool Get(User entity)
        {
            var result = false;
            if (entity.UserName != null || entity.Password != null)
            {
                result = _userDal.Get(entity);
            }

            return result;

        }

        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        private string GenerateToken(User user)
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
