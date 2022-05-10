using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace KyhCodeFirstWebApplication.Controllers;


public class TeamController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IToastNotification _toastNotification;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public TeamController(ApplicationDbContext context,
        IToastNotification toastNotification,
        IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _toastNotification = toastNotification;
        _webHostEnvironment = webHostEnvironment;
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
    public IActionResult Edit(int id)
    {
        var team = _context.Teams.FirstOrDefault(e => e.Id == id);
        var model = new TeamEditViewModel();
        model.Id = team.Id;
        model.Founded = team.FoundedYear;
        model.Name = team.Name;
        model.City = team.City;
        if(!string.IsNullOrEmpty(team.ImageFileName))
            model.PathToImage = "/uploaded/" + team.ImageFileName;
        return View(model);
    }


    [HttpPost]
    public IActionResult Edit(TeamEditViewModel model)
    {
        if (ModelState.IsValid)
        {
            var team = _context.Teams.FirstOrDefault(e => e.Id == model.Id);
            team.FoundedYear = model.Founded;
            team.Name = model.Name;
            team.City = model.City;
            if(model.Bild != null)
                team.ImageFileName = SaveNewFile( model.Bild );
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Denna sparades ok");
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    private string SaveNewFile(IFormFile modelBild)
    {   // laddar upp 0x0.jpg
        // fullFileName = "3321-321-321-321asda-dsa0x0.jpg"
        string fullFileName = Guid.NewGuid().ToString() + modelBild.FileName;
        string fullPath = Path.Combine(_webHostEnvironment.WebRootPath,
            "uploaded", 
            fullFileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            modelBild.CopyTo(stream);
        }

        return fullFileName;
    }
}