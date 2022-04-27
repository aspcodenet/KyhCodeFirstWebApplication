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

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        var team = _context.Teams.FirstOrDefault(e => e.Id == id);
        if (team == null) return NotFound();
        _context.Teams.Remove(team);
        _context.SaveChanges();
        return NoContent();
    }



    [HttpPut]
    [Route("{id}")]
    public IActionResult Uppdatera(int id, UpdateLagDTO laget)
    {
        var team = _context.Teams.FirstOrDefault(e => e.Id == id);
        if (team == null) return NotFound();

        team.Name = laget.Name;
        team.City = laget.City;
        team.FoundedYear = laget.FoundedYear;

        _context.SaveChanges();
        return NoContent();

    }


    [HttpPost]
    public IActionResult Create(CreateLagDTO laget)
    {
        var team = new Team
        {
            City = laget.City,
            FoundedYear = laget.FoundedYear,
            Name = laget.Name
        };
        _context.Teams.Add(team);
        _context.SaveChanges();

        var lagDTO = new LagDTO
        {
            City = team.City,
            FoundedYear = team.FoundedYear,
            Name = team.Name,
            Id = team.Id,
            Players = new List<PlayerDTO>()
        };
        return CreatedAtAction(nameof(GetOne), new {id = team.Id}, lagDTO);
    }

    [HttpGet]
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

    [HttpGet]
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
        return Ok(ret);
    }

}