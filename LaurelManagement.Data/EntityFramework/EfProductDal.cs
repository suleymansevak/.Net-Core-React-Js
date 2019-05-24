using LaurelManagement.Entity;
using LaurelManagement.Mvc.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Data.EntityFramework
{
   public class EfProductDal:EfEntityRepositoryBase<Product,LaurelDbContext>,IProductDal
    {

      
    }
}
