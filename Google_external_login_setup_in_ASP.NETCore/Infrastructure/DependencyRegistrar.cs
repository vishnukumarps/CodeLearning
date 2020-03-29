using Google_external_login_setup_in_ASP.NETCore.Controllers.Models;
using Google_external_login_setup_in_ASP.NETCore.IRepository;
using Google_external_login_setup_in_ASP.NETCore.Repository;
using Maintenance.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google_external_login_setup_in_ASP.NETCore.Infrastructure
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
         //   services.AddSingleton<SignInManager>();
            services.AddAuthentication()
            .AddGoogle(options=>{
                options.ClientId = "1003200139172-08ubkb9qm6j2mvinr4ifhkeak47hs2t6.apps.googleusercontent.com";
                options.ClientSecret = "GCAVYJ9NAu_uT-OxgsCIh3H3";
            });


      //      services.AddDefaultIdentity<IdentityUser>()
      //.AddRoles<IdentityRole>() // <--------
      //.AddDefaultUI(UIFramework.Bootstrap4)
      //.AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }

  //      public static IConfiguration Configuration { get; }

    }
}

