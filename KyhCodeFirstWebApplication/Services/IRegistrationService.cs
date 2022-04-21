namespace KyhCodeFirstWebApplication.Services;

public interface IRegistrationService
{
    // Register
    //Rules - ska misslyckas sig ifall man redan finns
    //          ska lyckas ifall man inte finns
    //      ska INTE skicka email om man finns
    //      ska skicka email om man finns
    //      vi tillåter bara Oslo som stad i Norge 

    public enum RegistrationStatus
    {
        Ok,
        AlreadyExists,
        NotAllowedCityCountryCombination
    }

    RegistrationStatus Register(string email, string name, string city, string country);


}