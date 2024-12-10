using ECOMMERECE.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Data.Models;
using Store.Services.DTO;
using Store.Services.interfaces;
using System.Text;
using System.Text.Json;

namespace ECOMMERECE.Attributes
{
    public class assignToken : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var tokenServices = context.HttpContext.RequestServices.GetService<ITokenServices>();
            var userServices = context.HttpContext.RequestServices.GetService<IUserService>();
            var userManager = context.HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>();
            var userDtoObject = (UserSignInDto)context.ActionArguments["userDTO"];
            var email = userDtoObject.Email;
            var exec = await next();
            if (exec.Result is OkResult)
            {
               var user = await userManager.FindByEmailAsync(email);
                var token = await tokenServices.createTokenAsync(user, userManager);
                exec.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                await exec.HttpContext.Response.WriteAsJsonAsync(new ApiResponse(StatusCodes.Status200OK,token));
                return;
            }

        }
    }
}
