using LaurelManagement.Business.Abstract;
using LaurelManagement.Data;
using LaurelManagement.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Business.Services
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public bool Add(Product entity)
        {
            var result = _productDal.Add(entity);

            return result;
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList()
        {
            var serviceResult = new List<Product>();
            try
            {
                var productList = _productDal.GetList();
                if (productList != null)
                {
                    serviceResult = productList;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return serviceResult;

        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
