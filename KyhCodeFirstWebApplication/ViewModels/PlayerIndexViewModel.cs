namespace KyhCodeFirstWebApplication.ViewModels;

public class PlayerIndexViewModel
{
    public List<PlayerIndexItemViewModel> Items { get; set; }

    public class PlayerIndexItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}