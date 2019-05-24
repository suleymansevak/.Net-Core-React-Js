using LaurelManagement.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Business.Abstract
{
   public interface IUserService
    {
        bool Add(User entity);
        void Update(User entity);
        void Delete(User entity);
        bool Get(User entity);
        List<User> GetList();
        User GetUserById(int id);
        User Authenticate(User entity);
    }
}
