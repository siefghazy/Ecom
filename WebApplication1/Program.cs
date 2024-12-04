
using ECOMMERECE.Controllers;
using ECOMMERECE.Errors;
using ECOMMERECE.middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo;
using Store.Repo.interfaces;
using Store.Repo.repos;
using Store.Services.interfaces;
using Store.Services.services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main (string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProduct, ProductRepo>();
            builder.Services.AddScoped<Ibrand, BrandsRepo>();
            builder.Services.AddScoped<IType, TypeRepo>();
            builder.Services.AddScoped<IbrandService, BrandServices>();
            builder.Services.AddScoped<IProductService, productServices>();
            builder.Services.AddScoped<ITypeService, TypeServices>();
            builder.Services.AddScoped<IImages, ImageRepo>();
            builder.Services.AddScoped<IimagesOnProduct, imageOnproductRepo>();
            builder.Services.AddDbContext<StoreDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            builder.Services.Configure<ApiBehaviorOptions>(
                option=>option.InvalidModelStateResponseFactory=(ActionContext) =>
                {
                    var errors = ActionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                    .SelectMany(e => e.Value.Errors)
                    .Select(e => e.ErrorMessage).ToArray();

                    var response = new apiValidationHandle()
                    {
                        Errors = errors
                    };
                    return  new BadRequestObjectResult(response);
                }
                ); //bad request exception 








            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleWare>(); //null-reference Exception

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
      
            app.UseStatusCodePagesWithReExecute("/error");// not found Route Exception
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
