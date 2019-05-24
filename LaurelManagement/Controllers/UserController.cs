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
    [TypeFilter(typeof(TokenAttribute))]
    public class UserController : Controller
    {
        private IUserService _userService;
        private readonly JwtConfig _jwt;
        public UserController(IUserService userService, IOptions<JwtConfig> jwt)
        {
            _jwt = jwt.Value;
            _userService = userService;
        }

       
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserModel userParam)
        {

            var user = _userService.Authenticate(new User
            {
                Id =userParam.Id,
                UserName=userParam.UserName,
                Password=userParam.Password
                
            });

            if (user == null)
            {
                return Unauthorized();
            }
            //user.Token = GenerateToken(user);

            return Ok(user);

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

        [Route("GetList")]
        public IActionResult GetUserList()
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
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


        private string GenerateToken(User user)
        {
            var Claims = new Claim[]
            {
                new Claim("id",user.Id.ToString()),
                new Claim("email",user.Email),
                new Claim("phone",user.Phone)
            };
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Secret));
            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Issuer,
                claims: Claims,
                expires: DateTime.Now.AddMinutes(_jwt.Expires),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}