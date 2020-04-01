using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DataContext;
using DAL.Interfaces;
using DAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
namespace GoogleLogin
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

            services.AddTransient<IUserDataService, UserDataService>();
            services.AddControllersWithViews();



            //var x = services.AddDbContextPool<DataBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConString")));
            //services.AddIdentity<IdentityUser, IdentityRole>(cfg =>
            //{
            //    cfg.User.RequireUniqueEmail = true;
            //}).AddEntityFrameworkStores<DataBaseContext>();


            services.AddAuthentication()
        .AddGoogle(options =>
        {
            IConfigurationSection googleAuthNSection =
                Configuration.GetSection("Authentication:Google");

            //  options.ClientId = googleAuthNSection["ClientId"];
            // options.ClientSecret = googleAuthNSection["ClientSecret"];



            options.ClientId = "441927107790-vjc4lo2g2i3tvdmagijleld5i7ank30p.apps.googleusercontent.com";
            options.ClientSecret = "1Lom9E1mObephg5OOir39VOc";
        });
            //.AddGoogle(options =>
            //{
            //    IConfigurationSection googleAuthNSection =
            //        Configuration.GetSection("Authentication:Google");

            //    options.ClientId = "756588286238-23ghppopff6kdkkpmfb8vun4l50nl19e.apps.googleusercontent.com";
            //    options.ClientSecret = "Tb8LmorqRfdYSP8SIm1KvNLq";
            //    options.CallbackPath="https://localhost:44380/signin-google";
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
