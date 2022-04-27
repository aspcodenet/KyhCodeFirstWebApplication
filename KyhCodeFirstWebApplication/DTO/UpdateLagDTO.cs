using System.ComponentModel.DataAnnotations;

namespace KyhCodeFirstWebApplication.DTO;

public class UpdateLagDTO
{
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(80)]
    public string City { get; set; }

    [Range(1800, 2030)]
    public int FoundedYear { get; set; }

}