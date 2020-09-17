using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore_CodeFirst.Db
{
    public static class DbServiceExtension
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString)
              => services.AddDbContext<CodeFirstDemoContext>(options => options.UseSqlServer(connectionString));
    }
}


