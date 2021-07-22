using Common.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly GeneralOptions _generalOptions;

        public EmailSender(IOptions<GeneralOptions> generalOptions)
        {
            _generalOptions = generalOptions.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _generalOptions.SendGridApiKey;

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_generalOptions.FromEmail, _generalOptions.FromName);
            var to = new EmailAddress(email);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
