using KyhCodeFirstWebApplication.Data;

namespace KyhCodeFirstWebApplication.Services;

public interface IMailingListService
{
    void SendEmail(string email, string header, string mailbody );
}

public class  MailingListService : IMailingListService
{
    private readonly ApplicationDbContext _context;

    public MailingListService(ApplicationDbContext context)
    {
        _context = context;
    }
    public void SendEmail(string email, string header, string mailbody)
    {
        //Skciakr mail

        // Skapa en logevent för denna user
        var user = _context.MailingListUsers.First(e => e.Email == email);
        user.Events.Add(new LogEvent
        {
            Action = "mail sent", // "created", ""
            Created = DateTime.Now
        });
        _context.SaveChanges();
    }
}

