using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazor.Extensions.Logging;

namespace Chapter11
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<LocalStorageProvider>();
            builder.Services.AddScoped<SessionStorageProvider>();

            builder.Services.AddScoped<ApplicationStorage<LocalStorageProvider>>();
            builder.Services.AddScoped<ApplicationStorage<SessionStorageProvider>>();

            builder.Services.AddLogging(builder => builder.AddBrowserConsole());

            await builder.Build().RunAsync();
        }
    }
}
