using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Repo;

namespace ECOMMERECE.Helper
{
    public class applySeeding
    {
        public static async Task applySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactpry = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = service.GetRequiredService<StoreDbContext>();
                    await StoreSeedData.SeedDataAsync(context, loggerFactpry);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactpry.CreateLogger<applySeeding>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
