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


    [HttpGet]
    public IActionResult Edit(int id) //OnGet
    {
        var model = new PlayerEditViewModel();
        var player = _context.Players.First(p => p.Id == id);
        model.JerseyNumber = player.JerseyNumber;
        model.Name = player.Name;
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(int id, PlayerEditViewModel model) 
    {
        if (ModelState.IsValid)
        {
            var player = _context.Players.First(p => p.Id == id);
            player.JerseyNumber = model.JerseyNumber;
            player.Name = model.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }





    [HttpGet]
    public IActionResult New() //OnGet
    {
        var model = new PlayerNewViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult New(PlayerNewViewModel model) //OnPost
    {
        if (ModelState.IsValid)
        {
            var player = new Player();
            player.Name = model.Name;
            player.JerseyNumber = model.JerseyNumber;
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
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