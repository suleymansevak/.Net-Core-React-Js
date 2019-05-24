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
        public bool Get(User entity)
        {
            var result = Get(x => x.UserName == entity.UserName && x.Password == entity.Password);
            // Any() geriye data dönerse true yada false dönmesini 
            return result != null ? true : false;
        }

        public User AuthenticateUser(User entity)
        {
            var result = Get(x => x.UserName == entity.UserName && x.Password == entity.Password);

            if(result==null)
            {
                return null;
            }

            return result;
        }
    }
}
