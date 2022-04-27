using Microsoft.EntityFrameworkCore;

namespace KyhCodeFirstWebApplication.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _context;

    public DataInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SeedData()
    {
        _context.Database.Migrate();
        SeedTeams();
    }

    private void SeedTeams()
    {
        if (!_context.Teams.Any(e => e.Name == "DIF"))
        {
            _context.Teams.Add(new Team {City = "Stockholm", FoundedYear = 1901, 
                Name = "DIF"});
        }
        if (!_context.Teams.Any(e => e.Name == "AIK"))
        {
            _context.Teams.Add(new Team
            {
                City = "Solna",
                FoundedYear = 1899,
                Name = "AIK"
            });
        }

        if (!_context.Teams.Any(e => e.Name == "Södertälje SK"))
        {
            _context.Teams.Add(new Team
            {
                City = "Södertälje",
                FoundedYear = 1111,
                Name = "Södertälje SK"
            });
        }


        _context.SaveChanges();
    }
}