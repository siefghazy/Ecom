using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Services.interfaces;
using System.Text;

namespace ECOMMERECE.Attributes
{
    public class Cached : Attribute, IAsyncActionFilter
    {
        private readonly int _timeout;
        public Cached(int timeOut)
        {
            _timeout = timeOut;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetService<ICacheService>(); //generate object from cache service 
            var cachKey = createCacheKey(context.HttpContext.Request);
            var redisResponse = await cacheService.getCacheAsync(cachKey);
            if (!string.IsNullOrEmpty(redisResponse))
            {
                var contentResult = new ContentResult()
                {
                    Content = redisResponse,
                    StatusCode = 200,
                    ContentType = "application/json"
                };
                context.Result = contentResult;
                return;
            }
            var execution = await next();
            if (execution.Result is OkObjectResult response)
            {
                await cacheService.setCacheKeyAsync(cachKey, response.Value, TimeSpan.FromSeconds(_timeout));
            }
        }
        public string  createCacheKey(HttpRequest request)
        {
            var cachKey = new StringBuilder();
            cachKey.Append($"{request.Path}");
            return cachKey.ToString();
        }
    }
}
