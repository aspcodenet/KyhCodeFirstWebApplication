using System.Runtime.InteropServices;
using AutoMapper;
using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KyhCodeFirstWebApplication.Controllers;

public class PlayerController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PlayerController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public IActionResult Edit(int id) //OnGet
    {
        var player = _context.Players.First(p => p.Id == id);

        var model = _mapper.Map<PlayerEditViewModel>(player);


        //model.JerseyNumber = player.JerseyNumber;
        //model.Name = player.Name;
        //model.Description = player.Description;
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(int id, PlayerEditViewModel model) 
    {
        if (ModelState.IsValid)
        {
            var player = _context.Players.First(p => p.Id == id);
            _mapper.Map(model, player);
            //player.JerseyNumber = model.JerseyNumber;
            //player.Name = model.Name;
            //player.Description = model.Description;


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
            //player = Mappa(model);
            player.Name = model.Name;
            player.JerseyNumber = model.JerseyNumber;
            player.Description = model.Description;
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