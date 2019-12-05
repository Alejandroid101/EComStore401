using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace ECom.Models.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(Configuration["SendGridEmail"]);
            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("donotreply@luxcars.com", "Page Admin");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);
        }
    }
}
