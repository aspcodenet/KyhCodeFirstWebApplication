using System.Linq;
using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Services;

class FakeEmailSenderService : IEmailSenderService
{
    public bool Called = false;
    public void SendEmail(string toEmail, string header, string body)
    {
        Called = true;
    }
}


[TestClass]
public class RegistrationServiceTests
{
    private RegistrationService _sut; // System under test
    private readonly FakeEmailSenderService _emailSender;
    private ApplicationDbContext _context;

    public RegistrationServiceTests()
    {
        _emailSender = new FakeEmailSenderService();
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;
        _context = new ApplicationDbContext(options);
        _sut = new RegistrationService(_emailSender, _context);
    }

    [TestMethod]
    public void When_using_hej_se_should_return_ok()
    {
        var result = _sut.Register("stefan@hej.se", "", "", "");
        Assert.AreEqual(IRegistrationService.RegistrationStatus.Ok, result);
    }

    [TestMethod]
    public void When_ok_should_send_email()
    {
        var result = _sut.Register("stefan@hej.se", "", "", "");
        Assert.IsTrue(_emailSender.Called);
    }


    [TestMethod]
    public void When_ok_should_store_in_database()
    {
        var result = _sut.Register("36131@hej.se", "", "", "");
        Assert.IsNotNull(_context.MailingListUsers.FirstOrDefault(e=>e.Email == "36131@hej.se"));
    }





    [TestMethod]
    public void When_using_hej_com_should_return_ok()
    {
        var result = _sut.Register("stefan@hej.com", "", "", "");
        Assert.AreEqual(IRegistrationService.RegistrationStatus.Ok, result);
    }

    [TestMethod]
    public void When_using_hejhej_com_should_return_invalid_domain()
    {
        var result = _sut.Register("stefan@hejhej.com", "", "", "");
        Assert.AreEqual(IRegistrationService.RegistrationStatus.InvalidEmailDomain,
            result);
    }



}