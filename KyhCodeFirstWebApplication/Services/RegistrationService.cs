namespace KyhCodeFirstWebApplication.Services;

public class RegistrationService : IRegistrationService
{
    public IRegistrationService.RegistrationStatus Register(string email, string name, string city, string country)
    {
        return IRegistrationService.RegistrationStatus.Ok;
    }
}