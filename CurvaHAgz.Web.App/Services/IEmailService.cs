namespace CurvaHAgz.Web.App.Services
{
    public interface IEmailService
    {
        Task SendAsync(string toEmail, string subject, string bodyHtml);
    }
}
