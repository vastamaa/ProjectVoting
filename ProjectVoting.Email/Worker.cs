using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Interfaces;
using SendWithBrevo;

namespace ProjectVoting.Email
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmailSender _emailSender;

        public Worker(ILogger<Worker> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _emailSender.SendEmail(new EmailMessage(new Sender("name", "email"), new List<Recipient> { new Recipient("name", "test@test.hu") }, "", ""));

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}
