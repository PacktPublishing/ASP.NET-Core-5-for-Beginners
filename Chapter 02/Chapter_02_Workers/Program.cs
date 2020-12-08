using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chapter_02_Workers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)  
                .UseWindowsService()
                .UseSystemd()              
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
