using System.Net.Mail;

namespace ProjectVoting.ApplicationCore.DTOs
{
    public class EmailOptions
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class EmailMessage
    {
        public List<MailAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public EmailMessage(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailAddress>();
            To.AddRange(to.Select(x => new MailAddress(x)));
            Subject = subject;
            Content = content;
        }
    }
}
