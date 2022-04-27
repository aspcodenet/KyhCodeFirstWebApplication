using KyhCodeFirstWebApplication.Data;
using KyhCodeFirstWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        return Ok(_context.Teams.ToList());

    }

    [Route("{id}")]
    public IActionResult GetOne(int id)
    {
        var team = _context.Teams.FirstOrDefault(e => e.Id == id);
        if (team == null)
            return NotFound();
        return Ok(team);
    }

}