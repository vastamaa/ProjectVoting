using Microsoft.Extensions.Configuration;
using ProjectVoting.ApplicationCore.DTOs;
using ProjectVoting.ApplicationCore.Interfaces;
using SendWithBrevo;

namespace ProjectVoting.ApplicationCore.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly BrevoClient _client;
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = GetEmailClient();
        }

        public async void SendEmail(EmailMessage message)
        {
            await _client.SendAsync(
                new Sender("name", "sender mail"),
                new List<Recipient> { new Recipient("Test", "recipient mail") },
                "Email subject",
                "Email body",
                false);
        }

        private BrevoClient GetEmailClient()
        {
            var apiKey = _configuration.GetSection("EmailOptions:ApiKey");
            return new BrevoClient(_configuration.GetSection("EmailOptions:ApiKey").Value);
        }
    }
}
