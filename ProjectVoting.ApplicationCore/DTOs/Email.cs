using SendWithBrevo;
using System.Diagnostics.CodeAnalysis;

namespace ProjectVoting.ApplicationCore.DTOs
{
    [ExcludeFromCodeCoverage]
    public class EmailMessage
    {
        public Sender Sender { get; set; }
        public List<Recipient> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public EmailMessage(Sender sender, IEnumerable<Recipient> to, string subject, string content)
        {
            Sender = sender;


            To = new List<Recipient>();
            To.AddRange(to.Select(x => new Recipient(x.Name, x.Email)));
            Subject = subject;
            Content = content;
        }
    }
}
