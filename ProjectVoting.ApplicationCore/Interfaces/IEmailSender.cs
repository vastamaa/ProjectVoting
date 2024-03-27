using ProjectVoting.ApplicationCore.DTOs;

namespace ProjectVoting.ApplicationCore.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmail(EmailMessage message);
    }
}