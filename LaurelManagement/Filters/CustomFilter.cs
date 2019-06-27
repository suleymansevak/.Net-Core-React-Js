
using LaurelManagement.Business.Abstract;
using LaurelManagement.Entity;
using LaurelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LaurelManagement.Filters
{
    public class TokenAttribute : ActionFilterAttribute
    {
        private readonly IUserService _userService;
        public TokenAttribute(IUserService userService)
        {
            _userService = userService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           var model = context.HttpContext.Request.Headers["Authorization"] ;
            if (model.ToString() != null || model.ToString() != string.Empty)
            {
                var result = _userService.GetUserByToken(model);

                if (result != null)
                {
                    base.OnActionExecuting(context);
                }
                else
                {
                   // context.Result = new UnauthorizedResult();

                   context.Result= new StatusCodeResult(401);
                }
            }
            else
            {
                context.Result = new StatusCodeResult(401);
            }
        }
    }
}
