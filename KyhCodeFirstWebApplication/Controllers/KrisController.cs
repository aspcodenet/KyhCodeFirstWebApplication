using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KyhCodeFirstWebApplication.Controllers;

public class KrisController : Controller
{
    private readonly IConfiguration _configuration;

    public KrisController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // GET
    public IActionResult Index()
    {
        var model = new KrisInfoListViewModel();
        model.Items = new List<KrisInfoListViewModel.KrisInfoListItemViewModel>();
        //Hämta alla från den urlen


        return View(model);
    }
}