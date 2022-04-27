namespace KyhCodeFirstWebApplication.DTO;

public class LagDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public int FoundedYear { get; set; }

    public List<PlayerDTO> Players { get; set; }
}