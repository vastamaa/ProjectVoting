using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectVoting.Infrastructure.Persistence.Models;
using ProjectVoting.ApplicationCore.Interfaces;
using ProjectVoting.ApplicationCore.Services;
using ProjectVoting.Infrastructure.Persistence.Contexts;
using System.Reflection;

namespace ProjectVoting.ApplicationCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
