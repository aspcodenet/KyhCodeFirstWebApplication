using KyhCodeFirstWebApplication.Services;
using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KyhCodeFirstWebApplication.Controllers;

public class KrisController : Controller
{
    private readonly IKrisInfoService _krisInfoService;

    public KrisController(IKrisInfoService krisInfoService)
    {
        _krisInfoService = krisInfoService;
    }

    // GET
    public IActionResult Index()
    {
        var model = new KrisInfoListViewModel();
        model.Items = _krisInfoService.GetLatest().Select(e=>new
            KrisInfoListViewModel.KrisInfoListItemViewModel
            {
                Headline = e.Headline,
                Identitifer = e.Identitifer
            }
            ).ToList();




        return View(model);
    }
}