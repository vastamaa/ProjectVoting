using ProjectVoting.ApplicationCore.Extensions;
using ProjectVoting.ApplicationCore.Interfaces;
using ProjectVoting.ApplicationCore.Services;

namespace ProjectVoting.Email
{
    public class Program
    {
        private IConfiguration configuration { get; }

        public Program(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddAPIClient();
                services.AddCustomEmailWorkerServices();
                services.AddHostedService<Worker>();
            });

            var host = builder.Build();
            host.Run();
        }
    }
}