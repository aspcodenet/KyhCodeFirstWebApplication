using System.Net.Mail;
using KyhCodeFirstWebApplication.Data;

namespace KyhCodeFirstWebApplication.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IEmailSenderService _emailSenderService;
    private readonly ApplicationDbContext _context;

    public RegistrationService(IEmailSenderService emailSenderService, 
        ApplicationDbContext context)
    {
        _emailSenderService = emailSenderService;
        _context = context;
    }
    public IRegistrationService.RegistrationStatus Register(string email, string name, string city, string country)
    {
        if (CheckCorrectDomain(email) == false)
            return IRegistrationService.RegistrationStatus.InvalidEmailDomain;


        SendWelcomeMail(email);

        _context.MailingListUsers.Add(new MailingListUser
        {
            City = city,
            Country = country,
            Email = email,
            Name = name

        });
        _context.SaveChanges();

        return IRegistrationService.RegistrationStatus.Ok;
    }

    private void SendWelcomeMail(string email)
    {
        _emailSenderService.SendEmail(email, "Welcome to the mailing list",
            "Big big welcome");
    }

    private bool CheckCorrectDomain(string email)
    {
        if (email.ToLower().EndsWith("@hej.se") || email.ToLower().EndsWith("@hej.com"))
            return true;
        return false;
    }
}