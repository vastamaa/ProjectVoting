using ProjectVoting.ApplicationCore.DTOs;

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
            var builder = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
            {
                var program = new Program(context.Configuration);

                services.Configure<EmailOptions>(program.configuration.GetSection("EmailOptions"));
                services.AddHostedService<Worker>();
            });

            var host = builder.Build();
            host.Run();
        }
    }
}