using System.ComponentModel.DataAnnotations;

namespace KyhCodeFirstWebApplication.ViewModels;

public class PlayerEditViewModel
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [Range(1, 100)]
    public int Trojnummer{ get; set; }

    public string Description { get; set; }

}