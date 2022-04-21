using KyhCodeFirstWebApplication.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.Services;

[TestClass]
public class RegistrationServiceTests
{
    private RegistrationService _sut; // System under test

    public RegistrationServiceTests()
    {
        _sut = new RegistrationService();
    }

    [TestMethod]
    public void When_using_hej_se_should_return_ok()
    {
        var result = _sut.Register("stefan@hej.se", "", "", "");
        Assert.AreEqual(IRegistrationService.RegistrationStatus.Ok, result);
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