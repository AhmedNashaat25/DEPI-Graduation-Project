using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CurvaHAgz.Web.App.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string toEmail, string subject, string bodyHtml)
        {
            Console.WriteLine($"Sending email to {toEmail}");  // Log to verify the recipient's email

            var fromAddress = new MailAddress("fantfoot024@gmail.com", "Curva Hagz");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "key"; // Use your app password

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = bodyHtml,
                IsBodyHtml = true
            })
            {
                await smtp.SendMailAsync(message);
            }
        }

    }
}
