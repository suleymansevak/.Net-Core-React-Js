using LaurelManagement.Entity;
using LaurelManagement.Mvc.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LaurelManagement.Data.EntityFramework
{
    public class EfUsersDal : EfEntityRepositoryBase<User, LaurelDbContext>, IUserDal
    {


        public User Get(User entity)
        {
            var result = Get(x => x.UserName == entity.UserName && x.Password == entity.Password);
            return result;

        }

        public User AuthenticateUser(string token)
        {
            var result = Get(x => x.Token == token);
            if (result != null && result.ExpireDate > DateTime.Now)
            {
                return result;
            }

            return null;
        }

        public User Login(User entity)
        {
            return entity;
        }
    }
}
