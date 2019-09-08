using LaurelManagement.Entity;
using LaurelManagement.Mvc;
using System.Collections.Generic;

namespace LaurelManagement.Business.Abstract
{
    public interface ICustomerService
    {
        bool Add(Customer entity);
        void Delete(Customer entity);
        void Update(Customer entity);
        List<Customer> GetList();
        Customer GetCustomerById(int id);
    }
}