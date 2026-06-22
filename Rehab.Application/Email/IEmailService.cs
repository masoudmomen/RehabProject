using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(IEnumerable<string> to, string subject, string body);

    }

    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {

            _config = config;
        }

        public async Task SendEmailAsync(IEnumerable<string> to, string subject, string body)
        {
            var recipients = to?.ToList();
            if(recipients == null || recipients.Count == 0) 
                throw  new ArgumentException("At least one recipients is required." , nameof(to));
                       
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_config["Email:From"]));
            foreach(var address in recipients)
                   message.To.Add(MailboxAddress.Parse(address));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await client.ConnectAsync(_config["Email:Host"], int.Parse(_config["Email:Port"]!),MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_config["Email:Username"], _config["Email:Password"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot connect to SMTP: {_config["Email:Host"]}:{_config["Email:Port"]} — {ex.Message}", ex);
            }


        }


    }
}
