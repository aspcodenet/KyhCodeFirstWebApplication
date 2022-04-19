namespace KyhCodeFirstWebApplication.ViewModels;

public class TeamIndexViewModel
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public List<TeamViewModel> Items { get; set; }
}