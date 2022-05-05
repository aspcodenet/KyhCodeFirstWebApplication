using System.ComponentModel.DataAnnotations;

namespace KyhCodeFirstWebApplication.Data;

public class Player
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    public int JerseyNumber { get; set; }

    public string Description { get; set; }
}