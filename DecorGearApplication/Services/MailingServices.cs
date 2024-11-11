using DecorGearApplication.IServices;
using DecorGearDomain.Data.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;





namespace DecorGearApplication.Services
{
    public class MailingServices : IMailingServices
    {
        private readonly MailSettings _mailSettings;
        private readonly IWebHostEnvironment _host;

        public MailingServices(IOptions<MailSettings> mailSettings, IWebHostEnvironment host)
        {
            _mailSettings = mailSettings.Value;
            _host = host;
        }

        public async Task<int> SendEmailAsync(string mailto, string subject, string body, IList<IFormFile> attachments = null)
        {
            if (string.IsNullOrEmpty(mailto))
            {
                throw new ArgumentNullException(nameof(mailto), "Recipient email cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentNullException(nameof(subject), "Subject cannot be null or empty.");
            }


            var emailBody = $"{body}";

            var email = new MimeMessage()
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = subject,
            };

            email.To.Add(MailboxAddress.Parse(mailto));

            var builder = new BodyBuilder
            {
                HtmlBody = emailBody
            };

            if (attachments != null)
            {
                foreach (var file in attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        builder.Attachments.Add(file.FileName, ms.ToArray(), ContentType.Parse(file.ContentType));
                    }
                }
            }

            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

            return 0;

        }
    }
}


