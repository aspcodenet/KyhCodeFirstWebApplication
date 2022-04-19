using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KyhCodeFirstWebApplication.Controllers;


public class TeamController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeamController(ApplicationDbContext context)
    {
        _context = context;
    }

    /*
            - skriver vi kod som "KONTROLLERAR FLÖDET" vad som ska hända
            - hämta från databas osv
            - validera
            - lägg properties i "Model"

     */
    public IActionResult Index()
    {
        var model = new TeamIndexViewModel
        {
            Items = _context.Teams.Select(e => new TeamIndexViewModel.TeamViewModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToList()
        };

        //Delegera till en View
        return View(model);

    }
    //public IActionResult New()
    //{

    //}
    //public IActionResult Edit()
    //{

    //}


}