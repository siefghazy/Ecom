using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repo
{
    public class StoreSeedData
    {
        public static async Task SeedDataAsync(StoreDbContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.ProdTypes != null && !context.ProdTypes.Any())
                {
                    var typesData = File.ReadAllText("../Store.Repo/seedData/types.json");
                    var types = JsonSerializer.Deserialize<List<prodType>>(typesData);
                    if (types != null)
                    {
                        await context.ProdTypes.AddRangeAsync(types);
                    }
                }
                if (context.Brands != null && !context.Brands.Any())
                {
                    var brandsData = File.ReadAllText("../Store.Repo/seedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<prodBrand>>(brandsData);
                    if (brands != null)
                    {
                        await context.Brands.AddRangeAsync(brands);
                    }
                }
                if (context.Products != null && !context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Store.Repo/seedData/products.json");
                    var products = JsonSerializer.Deserialize<List<product>>(productsData);
                    if (products != null)
                    {
                        await context.Products.AddRangeAsync(products);
                    }
                }
                context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreDbContext>();
                logger.LogError(e.Message);
            }

        }
    }
}
