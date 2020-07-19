using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter_03_QuickStart.DataManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Chapter_03_QuickStart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////TRANSIENT LIFETIME EXAMPLE
            services.AddTransient<IMusicManager, MusicManager>();

            ////SCOPED LIFETIME EXAMPLE
            //services.AddScoped<IMusicManager, MusicManager>();

            ////SINGLETON LIFETIME EXAMPLE
            //services.AddSingleton<IMusicManager, MusicManager>();
            //services.AddSingleton<IMusicManager, AwesomeMusicManager>();

            ////SERVICE DESCRIPTOR EXAMPLE 1
            //var serviceDescriptor = new ServiceDescriptor
            //(
            //    typeof(IMusicManager),
            //    typeof(MusicManager),
            //    ServiceLifetime.Singleton
            //);

            ////SERVICE DESCRIPTOR EXAMPLE 2
            //var serviceDescriptor = ServiceDescriptor.Describe
            //(
            //    typeof(IMusicManager),
            //    typeof(MusicManager),
            //    ServiceLifetime.Singleton
            //);

            ////SERVICE DESCRIPTOR EXAMPLE 3
            //var serviceDescriptor = ServiceDescriptor.Singleton
            //(
            //    typeof(IMusicManager),
            //    typeof(MusicManager)
            //);

            ////SERVICE DESCRIPTOR EXAMPLE 3
            //var serviceDescriptor = ServiceDescriptor
            //                       .Singleton<IMusicManager,MusicManager>();

            ////ADDs THE SERVICE DESCRIPTOR
            //services.Add(serviceDescriptor);

            ////DUPILCATE SERVICE REGISTRATION EXAMPLE
            //services.AddSingleton<IMusicManager, MusicManager>();
            //services.TryAddSingleton<IMusicManager, AwesomeMusicManager>();

            ////REPLACE SERVICE REGISTRATION EXAMPLE
            //services.AddSingleton<IMusicManager, MusicManager>();
            //services.Replace(ServiceDescriptor
            //               .Singleton<IMusicManager, AwesomeMusicManager>());

            ////REMOVE SERVICE REGISTRATION EXAMPLE
            //services.AddSingleton<IMusicManager, MusicManager>();
            //services.AddSingleton<IMusicManager, AwesomeMusicManager>();
            //services.RemoveAll<IMusicManager>();

            ////MULTIPLE REGISTRATION EXAMPLE
            //services.TryAddEnumerable(ServiceDescriptor
            //               .Singleton<IMusicManager, MusicManager>());
            //services.TryAddEnumerable(ServiceDescriptor
            //               .Singleton<IMusicManager, AwesomeMusicManager>());

            //SERVICE LIFETIME EXAMPLE
            services.AddTransient<InstrumentalMusicManager>();

            //PROPERTY EXAMPLE
            services.AddTransient<MusicManager>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

