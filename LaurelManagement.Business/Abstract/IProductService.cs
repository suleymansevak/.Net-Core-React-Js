using LaurelManagement.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Business.Abstract
{
  public  interface IProductService
    {
        bool Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        List<Product> GetList();
        Product GetProductById(int id);
    }
}
