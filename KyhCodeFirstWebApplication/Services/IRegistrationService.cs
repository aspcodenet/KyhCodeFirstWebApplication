namespace KyhCodeFirstWebApplication.Services;

public interface IRegistrationService
{
    // Register
    //Rules - ska misslyckas sig ifall man redan finns
    //          ska lyckas ifall man inte finns
    //      ska INTE skicka email om man finns
    //      ska skicka email om man INTE finns
    //      vi tillåter bara @hej.se och @hej.com som epostadress
    //      vi tillåter bara Oslo som stad i Norge 
    public enum RegistrationStatus
    {
        Ok,
        AlreadyExists,
        InvalidEmailDomain,
        NotAllowedCityCountryCombination
    }
    RegistrationStatus Register(string email, string name, string city, string country);
}