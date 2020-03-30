using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class DataBaseContext: IdentityDbContext
    {
        public class OptionBuild
        {
            public OptionBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
                opsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = opsBuilder.Options;
            }

            public DbContextOptionsBuilder<DataBaseContext> opsBuilder { get; set; }
            public DbContextOptions<DataBaseContext>dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }
         public static OptionBuild ops = new OptionBuild();

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RegisterViewModel> RegisterUsers { get; set; }
       
    }
}
