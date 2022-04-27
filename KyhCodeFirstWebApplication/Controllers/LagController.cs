using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.DTO;
using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KyhCodeFirstWebApplication.Controllers;

[Route("api/[controller]")] // surfa till  /api/lag
[ApiController]
public class LagController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LagController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return Ok(_context.Teams.Select(e=>new LagItemDTO
        {
            City  = e.City,
            FoundedYear = e.FoundedYear,
            Id = e.Id,
            Name = e.Name
        }).ToList());

    }

    [Route("{id}")]
    public IActionResult GetOne(int id)
    {
        var team = _context.Teams.Include(e=>e.Players).FirstOrDefault(e => e.Id == id);
        if (team == null)
            return NotFound();
        var ret = new LagDTO
        {
            FoundedYear = team.FoundedYear,
            Name = team.Name,
            City = team.City,
            Id = team.Id,
            Players = team.Players.Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                JerseyNumber = p.JerseyNumber,
            }).ToList()
        };
        return Ok(team);
    }

}