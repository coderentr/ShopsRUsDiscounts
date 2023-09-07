using System;
using Microsoft.EntityFrameworkCore;
using ShopsRUsDiscounts.Infrastructure.Context;

namespace ShopsRUsDiscounts.Api.Helpers
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ShopsRUsDiscountsDBContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return webApp;
        }
    }

}

