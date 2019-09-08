using LaurelManagement.Entity;
using LaurelManagement.Mvc.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LaurelManagement.Data
{
    public interface IUserDal : IEntityRepository<User>
    {
        User Get(User entity);
        User AuthenticateUser(string token);
        User Login(User entity);
    }
}
