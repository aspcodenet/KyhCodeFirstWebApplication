namespace KyhCodeFirstWebApplication.Services;

public class RegistrationService : IRegistrationService
{
    public IRegistrationService.RegistrationStatus Register(string email, string name, string city, string country)
    {
        if (CheckCorrectDomain(email) == false)
            return IRegistrationService.RegistrationStatus.InvalidEmailDomain;
        return IRegistrationService.RegistrationStatus.Ok;
    }

    private bool CheckCorrectDomain(string email)
    {
        if (email.ToLower().EndsWith("@hej.se") || email.ToLower().EndsWith("@hej.com"))
            return true;
        return false;
    }
}