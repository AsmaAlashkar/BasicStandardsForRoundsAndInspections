
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.EmailDTO;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class EmailSender:IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }
        
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpServer = _config["EmailConfiguration:SmtpServer"];
            var smtpPort = int.Parse(_config["EmailConfiguration:Port"]!);
            var from = _config["EmailConfiguration:From"];
            string appSpecificPassword = "tkqz hjao zhxa bojm";//TODO: move to config

            var content = new EmailMessage()
            {
                From = from,
                To = email,
                MessageText = message,
                Subject = subject
            };

            using var client = new SmtpClient();

            client.Connect(smtpServer, smtpPort, true);
            client.Authenticate(from, appSpecificPassword);
            client.Send(content.GetMessage());
            client.Disconnect(true);

        }

    }
}

