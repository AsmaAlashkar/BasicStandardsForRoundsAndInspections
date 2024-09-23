using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.EmailDTO
{
    public class EmailMessage
    {
        public string To { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string MessageText { get; set; } = string.Empty;

        public MimeMessage GetMessage()
        {
            var body = MessageText;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Almostakbal Technology", From));
            message.To.Add(new MailboxAddress("user", To));
            message.Subject = Subject;
            message.Body = new TextPart("plain") { Text = body };
            return message;
        }
    }
}
