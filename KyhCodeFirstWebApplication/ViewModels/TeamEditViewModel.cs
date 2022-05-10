namespace KyhCodeFirstWebApplication.ViewModels;

public class TeamEditViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Founded { get; set; }
    public string City { get; set; }

    public string? PathToImage { get; set; }
    public IFormFile? Bild { get; set; }
}