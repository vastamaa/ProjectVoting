using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectVoting.ApplicationCore.Interfaces;
using ProjectVoting.ApplicationCore.Services;
using ProjectVoting.Infrastructure.Persistence.Contexts;
using ProjectVoting.Infrastructure.Persistence.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ProjectVoting.ApplicationCore.Extensions
{
    [ExcludeFromCodeCoverage]
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

        // Source: https://www.milanjovanovic.tech/blog/the-right-way-to-use-httpclient-in-dotnet
        public static IHttpClientBuilder AddAPIClient(this IServiceCollection services)
        {
            return services.AddHttpClient("API", (serviceProvider, client) =>
            {
                client.BaseAddress = new Uri("http://localhost:5217/");
            });
        }

        public static IServiceCollection AddCustomEmailWorkerServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IHttpRequestService, HttpRequestService>();

            return services;
        }
    }
}
