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

        public async Task SendEmail(EmailMessage message)
        {
            await _client.SendAsync(
                message.Sender,
                message.To,
                message.Subject,
                message.Content,
                isHtml: false);
        }

        private BrevoClient GetEmailClient()
        {
            return new BrevoClient(_configuration.GetSection("EmailOptions:ApiKey").Value);
        }
    }
}
