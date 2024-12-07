using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Data.Models;
using Store.Services.interfaces;

namespace ECOMMERECE.Attributes
{
    public class checkEmail : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userManager= context.HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();
            var reqForm = context.HttpContext.Request.Form;
            var UserMail = reqForm["Email"];
            var user = userManager.FindByEmailAsync(UserMail);
            if (user is not null)
            {
                var res = new ContentResult()
                {
                    Content = "u Have Account Already",
                    StatusCode = StatusCodes.Status400BadRequest,
                    ContentType = "application/json"
                };
                context.Result = res;
            }
            await next();
        }
    }
}
