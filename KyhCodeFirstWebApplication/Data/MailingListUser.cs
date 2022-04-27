namespace KyhCodeFirstWebApplication.Data;

public class MailingListUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public List<LogEvent> Events { get; set; }

}

public class LogEvent
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string Action { get; set; }
}