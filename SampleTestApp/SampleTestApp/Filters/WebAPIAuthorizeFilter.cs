using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Domain;

namespace SampleTestApp.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class WebAPIAuthorizeAttribute : TypeFilterAttribute
    {
        public WebAPIAuthorizeAttribute(params string[] roles) : base(typeof(WebAPIAuthorizeFilter))
        {
            Arguments = new object[] { roles };
        }
    }

    public class WebAPIAuthorizeFilter : IAuthorizationFilter
    {
        readonly string[] _roles;
        public WebAPIAuthorizeFilter(params string[] roles)
        {
            _roles = roles;

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = RequestHandler.GetToken(context.HttpContext.Request);
            var validateStatus = false;
            if (!string.IsNullOrEmpty(token))
            {
               //TODO
            }
            //temp
            validateStatus = true;
            if (!validateStatus)
            {
                // context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Set HTTP 401 -   
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
