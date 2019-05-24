
using LaurelManagement.Business.Abstract;
using LaurelManagement.Entity;
using LaurelManagement.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaurelManagement.Filters
{
    public class TokenAttribute:ActionFilterAttribute
    {
        private readonly IUserService _userService;
        public TokenAttribute(IUserService userService)
        {
            _userService = userService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            var model = context.ActionArguments["model"] as User;
            var token = model.Token;
            
           // var result=
           
            base.OnActionExecuting(context);
        }
    }
}
