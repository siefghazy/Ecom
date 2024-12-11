using ECOMMERECE.Controllers;
using ECOMMERECE.Errors;
using ECOMMERECE.middlewares;
using ECOMMERECE.Seeding;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo;
using Store.Repo.interfaces;
using Store.Repo.repos;
using Store.Services.interfaces;
using Store.Services.services;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main (string[] args)
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
            builder.Services.AddScoped<Iuser, UserRepo>();
            builder.Services.AddScoped<IbrandService, BrandServices>();
            builder.Services.AddScoped<IProductService, productServices>();
            builder.Services.AddScoped<ITypeService, TypeServices>();
            builder.Services.AddScoped<IImages, ImageRepo>();
            builder.Services.AddScoped<IVariance, varianceRepo>();
            builder.Services.AddScoped<IimagesOnProduct, imageOnproductRepo>();
            builder.Services.AddScoped<ICacheService, CacheServices>();
            builder.Services.AddScoped<IUserService, userServices>();
            builder.Services.AddScoped<ITokenServices, TokenServices>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(
                options=>options.TokenValidationParameters=new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer= "https://localhost:7087/",
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("StrongAuthenticateStrongAuthenticateStrongAuthenticate"))
                });

            builder.Services.AddSingleton<IConnectionMultiplexer>((ServiceProvider) =>
            {
                var connection = builder.Configuration.GetConnectionString("redis");
                return ConnectionMultiplexer.Connect(connection);
            });
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            });
            builder.Services.AddDbContext<StoreDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            builder.Services.Configure<ApiBehaviorOptions>(
                option => option.InvalidModelStateResponseFactory = (ActionContext) =>
                {
                    var errors = ActionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                    .SelectMany(e => e.Value.Errors)
                    .Select(e => e.ErrorMessage).ToArray();

                    var response = new apiValidationHandle()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                }
                ); //bad request exception 
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<StoreDbContext>();
            var app = builder.Build();
           using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await roleSeeding.seedRoles(roleManager);
            }
            app.UseMiddleware<ExceptionMiddleWare>(); //null-reference Exception
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
      
            app.UseStatusCodePagesWithReExecute("/error");// not found Route Exception
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
