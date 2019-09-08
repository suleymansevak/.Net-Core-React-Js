using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LaurelManagement.Business.Abstract;
using LaurelManagement.Config;
using LaurelManagement.Entity;
using LaurelManagement.Filters;
using LaurelManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LaurelManagement.Controllers
{

    [Produces("application/json")]
    [Route("api/User")]
    [EnableCors("MyPolicy")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private readonly JwtConfig _jwt;
        public UserController(IUserService userService, IOptions<JwtConfig> jwt)
        {
            _jwt = jwt.Value;
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login (User model)
        {
            if (model==null)
            {
                return BadRequest();
            }

            var result = _userService.Login(model);
            if (result==null)
            {
              return  NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("UserCheck")]
        public IActionResult CheckUser([FromBody] User model)
        {
            if (model.UserName != null || model.Password != null)
            {
                var result = _userService.Get(model);

                return Ok(result);
            }
            return NotFound();
        }

        [TypeFilter(typeof(TokenAttribute))]
        [HttpGet]
        [Route("GetList")]
        public IActionResult GetUserList()
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        [TypeFilter(typeof(TokenAttribute))]
        public IActionResult Register([FromBody] UserModel model)
        {
            if (model != null)
            {
                var result = _userService.Add(new User
                {
                    Id=model.Id,
                    Name=model.Name,
                    Surname=model.Surname,
                    UserName=model.UserName,
                    Password=model.Password,
                    Email=model.Email,
                    Phone=model.Phone
                }
                );
                return Ok(result);
            }
            return NotFound();
        }

    }
}