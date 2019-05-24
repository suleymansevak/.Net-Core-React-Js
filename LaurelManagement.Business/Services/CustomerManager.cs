using LaurelManagement.Business.Abstract;
using LaurelManagement.Data;
using LaurelManagement.Entity;
using LaurelManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaurelManagement.Business.Services
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public bool Add(CustomerTemplate template)
        {

            try
            {
                if (template != null)
                {
                  var result=_customerDal.Add(new Customer
                    {
                        Country = template.Country,
                        FirstName = template.FirstName,
                        LastName = template.LastName
                    });
                    return result;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetList()
        {
            var serviceResult = new List<Customer>();
            try
            {
                var customerList = _customerDal.GetList();
                if (customerList != null)
                {
                    serviceResult = customerList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return serviceResult;


        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
