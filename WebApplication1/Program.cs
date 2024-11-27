
using ECOMMERECE.Controllers;
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
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //await applySeeding.applySeedingAsync(app);
            app.MapControllers();
            app.Run();
        }
    }
}
