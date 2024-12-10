using ECOMMERECE.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var UserMail = reqForm["Email"].ToString();
            var user = await userManager.FindByEmailAsync(UserMail);
            if (user is not null)
            {
                context.HttpContext.Response.StatusCode =StatusCodes.Status400BadRequest;
                await context.HttpContext.Response.WriteAsJsonAsync(new ApiResponse(StatusCodes.Status400BadRequest, "u have account"));
                return;
            }
            await next();
        }
    }
}
