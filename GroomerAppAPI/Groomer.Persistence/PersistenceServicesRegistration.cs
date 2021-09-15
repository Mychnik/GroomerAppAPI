using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Persistence
{
  public static  class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GroomerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("GroomerDbConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
             {
                 config.Password.RequiredLength = 8;
                 config.Password.RequireDigit = true;
                 config.Password.RequireNonAlphanumeric = true;
                 config.Password.RequireUppercase = true;
             }).AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<GroomerDbContext>()
             .AddDefaultTokenProviders();
            return services;
        }
    }
}
