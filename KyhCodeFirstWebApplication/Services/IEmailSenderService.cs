namespace KyhCodeFirstWebApplication.Services;

public interface IEmailSenderService
{
    void SendEmail(string toEmail, string header, string body );
}