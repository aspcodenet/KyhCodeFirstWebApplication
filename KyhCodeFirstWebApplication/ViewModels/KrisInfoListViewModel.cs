namespace KyhCodeFirstWebApplication.ViewModels;

public class KrisInfoListViewModel
{
    public List<KrisInfoListItemViewModel> Items { get; set; }

    public class KrisInfoListItemViewModel
    {
        public string Headline { get; set; }
        public string Identitifer { get; set; }

    }
}