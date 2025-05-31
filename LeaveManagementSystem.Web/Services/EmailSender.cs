
using System.Net.Mail;

namespace LeaveManagementSystem.Web.Services
{

    // Accesing configuration settings in runtime.
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            // Set up the SMTP client configuration settings
            var fromAddress = _configuration["EmailSettings:DefaultEmailAddress"];
            var smtpServer = _configuration["EmailSettings:Server"];
            var smtpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);

            // Set up the Message.
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            // Add the recipient email address.
            message.To.Add(new MailAddress(email));

            // Send the email using SmtpClient.
            using var client = new SmtpClient(smtpServer, smtpPort);
            await client.SendMailAsync(message);
        }
    }
}
