using System.ComponentModel.DataAnnotations;

namespace KyhCodeFirstWebApplication.Data;

public class Team
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string City { get; set; }
    public int FoundedYear { get; set; }

    public List<Player> Players { get; set; } = new List<Player>();

    [MaxLength(100)]
    public string ImageFileName { get; set; }
}