using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PlaceApi.Db
{
    public static class PlaceDbServiceExtension
    {
        public static void AddInMemoryDatabaseService(this IServiceCollection services, string dbName)
               => services.AddDbContext<PlaceDbContext>(options => options.UseInMemoryDatabase(dbName));

        public static void InitializeSeededData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var service = serviceScope.ServiceProvider;
            PlaceDbSeeder.Seed(service);
        }
    }
}
