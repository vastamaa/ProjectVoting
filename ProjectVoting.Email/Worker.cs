using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Interfaces;
using SendWithBrevo;

namespace ProjectVoting.Email
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IHttpRequestService _httpRequestService;

        public Worker(ILogger<Worker> logger, IEmailSender emailSender, IHttpRequestService httpRequestService)
        {
            _logger = logger;
            _emailSender = emailSender;
            _httpRequestService = httpRequestService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var unconfirmedUsers = await _httpRequestService.GetAsync();

                foreach (var user in unconfirmedUsers)
                {
                    _emailSender.SendEmail(new EmailMessage(new Sender("ProjectVoting", user.Email), new List<Recipient> { new Recipient($"{user.FirstName} {user.LastName}", user.Email) }, "Verify your account!", "Please verify your account by clicking on the following link: vjzwkdwanld"));
                }

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}
