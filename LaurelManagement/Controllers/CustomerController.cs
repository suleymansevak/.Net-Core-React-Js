using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaurelManagement.Business.Abstract;
using LaurelManagement.Entity;
using LaurelManagement.Filters;
using LaurelManagement.Models;
using LaurelManagement.Mvc;
using LaurelManagement.Mvc.Helper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaurelManagement.Controllers
{
    [Produces("application/json")]
    [EnableCors("MyPolicy")]
    [Route("api/Customer")]
    [TypeFilter(typeof(TokenAttribute))]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            var customerList = _customerService.GetList();
            CustomersModel model = new CustomersModel();
            model.customerList = customerList;

            return Ok(model);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCustomer(CustomersModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
            _customerService.Add(new Customer
            {
                Country = model.Country,
                FirstName = model.FirstName,
                LastName = model.LastName
            });

            return Ok();
        }

    }
}