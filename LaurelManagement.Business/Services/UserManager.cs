using LaurelManagement.Business.Abstract;
using LaurelManagement.Business.Services;
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
        private ITokenService _tokenservice;
        private readonly JwtConfig _jwtConfig;
        public UserManager(IUserDal userDal, IOptions<JwtConfig> jwtConfig,ITokenService tokenservice)
        {
            _userDal = userDal;
            _jwtConfig = jwtConfig.Value;
            _tokenservice = tokenservice;
        }
        
        
        public bool Add(User entity)
        {
            entity.Token = _tokenservice.GenerateToken(entity);
            var result = _userDal.Add(entity);
            return result;
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

        public User GetUserByToken(string token)
        {
            if (token != null)
            {
                var result = _userDal.AuthenticateUser(token);
                return result;
            }
            return null;

        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        
        public User Login(User entity)
        {
            entity.Token = _tokenservice.GenerateToken(entity);
            return entity;
        }
    }
}
