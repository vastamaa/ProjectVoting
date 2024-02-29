using ProjectVoting.ApplicationCore.DTOs;

namespace ProjectVoting.ApplicationCore.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage message);
    }
}