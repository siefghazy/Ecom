
using ECOMMERECE.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Repo;

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
            builder.Services.AddDbContext<StoreDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
