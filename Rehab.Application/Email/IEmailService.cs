using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rehab.Application.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(IEnumerable<string> to, string subject, string body);

    }

    public class EmailService : IEmailService
    {
        private static readonly TimeSpan SendTimeout = TimeSpan.FromSeconds(15);

        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration config, ILogger<EmailService> logger)
        {

            _config = config;
            _logger = logger;
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

            var host = _config["Email:Host"];
            var port = int.Parse(_config["Email:Port"]!);

            using var client = new MailKit.Net.Smtp.SmtpClient();
            using var cts = new CancellationTokenSource(SendTimeout);
            try
            {
                await client.ConnectAsync(host, port, MailKit.Security.SecureSocketOptions.StartTls, cts.Token);
                await client.AuthenticateAsync(_config["Email:Username"], _config["Email:Password"], cts.Token);
                await client.SendAsync(message, cts.Token);
                await client.DisconnectAsync(true, cts.Token);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, "Timed out sending email via {Host}:{Port} to {Recipients} after {Timeout}s", host, port, string.Join(",", recipients), SendTimeout.TotalSeconds);
                throw new Exception($"Timed out connecting to SMTP server {host}:{port} after {SendTimeout.TotalSeconds}s.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email via {Host}:{Port} to {Recipients}", host, port, string.Join(",", recipients));
                throw new Exception($"Cannot connect to SMTP: {host}:{port} — {ex.Message}", ex);
            }


        }


    }
}
