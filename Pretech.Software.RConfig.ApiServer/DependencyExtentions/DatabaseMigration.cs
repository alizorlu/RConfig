using Microsoft.EntityFrameworkCore;
using Pretech.Software.RConfig.Core.DBContext;
using System.Threading;

namespace Pretech.Software.RConfig.ApiServer.DependencyExtentions
{
    public static class DatabaseMigration
    {
        public static async Task DBMigrationConfigure(this IServiceCollection services)
        {
            #region All Migration

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<RConfigContext>();

                if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    await dbContext.Database.MigrateAsync();
                }
            }


            #endregion
        }
    }
}
