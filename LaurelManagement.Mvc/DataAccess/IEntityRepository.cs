using LaurelManagement.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LaurelManagement.Mvc.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        bool Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetList(Expression<Func<T, bool>> filter = null);  // parametre girmezse kullanıcı , default değer  "null". 
        T Get(Expression<Func<T, bool>> filter = null);
    }
}
