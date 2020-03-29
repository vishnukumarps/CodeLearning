using Google_external_login_setup_in_ASP.NETCore.IRepository;
using Google_external_login_setup_in_ASP.NETCore.Repository;
using Maintenance.DbModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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


          

            return services;
        }

  //      public static IConfiguration Configuration { get; }

    }
}

