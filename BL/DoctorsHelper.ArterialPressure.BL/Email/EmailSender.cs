using System.Threading.Tasks;
using DoctorsHelper.BL.Core.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace DoctorsHelper.ArterialPressure.BL.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderConfiguration _emailSenderConfiguration;

        public EmailSender(IOptions<EmailSenderConfiguration> emailSenderConfiguration)
        {
            _emailSenderConfiguration = emailSenderConfiguration.Value;
        }

        /// <inheritdoc />
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailSenderConfiguration.EmailSenderName, _emailSenderConfiguration.EmailSenderEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();

            await client.ConnectAsync(_emailSenderConfiguration.SmtpServerHost, _emailSenderConfiguration.SmtpServerPort, true);
            await client.AuthenticateAsync(_emailSenderConfiguration.EmailSenderEmail, _emailSenderConfiguration.EmailSenderPassword);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}