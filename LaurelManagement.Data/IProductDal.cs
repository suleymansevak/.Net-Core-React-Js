using LaurelManagement.Entity;
using LaurelManagement.Mvc.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Data
{
   public interface IProductDal:IEntityRepository<Product>
    {
       
    }
}
