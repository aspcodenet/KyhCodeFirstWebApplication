using System.Linq;
using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Services;

[TestClass]
public class MailingListServiceTests
{
    private readonly MailingListService _sut;
    private ApplicationDbContext _context;

    public MailingListServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;
        _context = new ApplicationDbContext(options);
        _sut = new MailingListService(_context);
    }

    [TestMethod]
    public void When_sending_mail_a_log_event_should_be_created()
    {
        // Arrange
        _context.MailingListUsers.Add(new MailingListUser
        {
            City = "321321",
            Country = "", Email = "stefan@hej.se", Name = "Stefan"
        });
        _context.SaveChanges();


        // Act
        _sut.SendEmail("stefan@hej.se", "Hej", "nytt mailutckick bla bla");

        //Assert
        var user = _context.MailingListUsers.Include(e=>e.Events)
            .First(e => e.Email == "stefan@hej.se");
        var ev = user.Events.Last();
        Assert.AreEqual("mail sent", ev.Action);

    }
}