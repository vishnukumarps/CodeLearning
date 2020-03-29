using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google_external_login_setup_in_ASP.NETCore.Infrastructure;
using Google_external_login_setup_in_ASP.NETCore.IRepository;
using Google_external_login_setup_in_ASP.NETCore.Repository;
using Maintenance.DbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Google_external_login_setup_in_ASP.NETCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            /*  var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .AddJsonFile($"appsettings:json.{env.EnviornmentName}.json", optional: true)
                              .AddEnviormentVariables();
  */


            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusiness();
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddMvc();
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddControllersWithViews();
            services.AddSession();

            services.Configure<Settings>(o => { o.iConfigurationRoot = (IConfigurationRoot)Configuration; });
            services.AddDistributedMemoryCache();
           // services.AddSession(option => option.IdleTimeout = TimeSpan.FromSeconds(3600));

            //services.AddAntiforgery(options =>
            //{
            //    options.Cookie.Name = "X-CSRF-TOKEN-MOONGLADE";
            //    options.FormFieldName = "CSRF-TOKEN-MOONGLADE-FORM";
            //});
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
            app.UseSession();//session added
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
