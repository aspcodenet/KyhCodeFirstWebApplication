using System.Net.Mail;

namespace KyhCodeFirstWebApplication.Services;

public class EmailSenderService : IEmailSenderService
{
    public void SendEmail(string toEmail, string header, string body)
    {
        var smtpClient = new SmtpClient();
        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@hej.se"),
            Subject = header,
            Body = body,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(toEmail);

        smtpClient.Send(mailMessage);

    }
}