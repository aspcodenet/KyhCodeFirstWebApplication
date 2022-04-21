namespace KyhCodeFirstWebApplication.Services;

public interface IRegistrationService
{
    // Register
    //Rules - ska misslyckas sig ifall man redan finns
    //          ska lyckas ifall man inte finns
    //      ska INTE skicka email om man finns
    //      ska skicka email om man finns
    //      vi tillåter bara Oslo som stad i Norge 
    //      vi tillåter bara @hej.se och @hej.com som epostadress

    public enum RegistrationStatus
    {
        Ok,
        AlreadyExists,
        InvalidEmailDomain,
        NotAllowedCityCountryCombination
    }
    RegistrationStatus Register(string email, string name, string city, string country);
}