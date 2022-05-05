using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KyhCodeFirstWebApplication.Controllers;

public class PlayerController : Controller
{
    private readonly ApplicationDbContext _context;

    public PlayerController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        //1. Hämta data från databas
        //2. populera en "snäll" vymodell med exakta properties som ska ritas ut
        var model = new PlayerIndexViewModel();
        model.Items = _context.Players.Select(e => new PlayerIndexViewModel.PlayerIndexItemViewModel
        {
            Name = e.Name,
            Id = e.Id
        }).ToList();

        //3. Anropa View
        return View(model);
    }
}