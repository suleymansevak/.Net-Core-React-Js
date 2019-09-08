using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaurelManagement.Business.Abstract;
using LaurelManagement.Entity;
using LaurelManagement.Filters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaurelManagement.Controllers
{
    [Produces("application/json")]
    [EnableCors("MyPolicy")]
    [Route("api/Product")]
    [TypeFilter(typeof(TokenAttribute))]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult InsertProduct([FromBody] Product model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            _productService.Add(model);
            return Ok();
        }
    }
}