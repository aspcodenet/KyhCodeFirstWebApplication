using Microsoft.EntityFrameworkCore;

namespace KyhCodeFirstWebApplication.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {
        
    }

    public DbSet<Team> Teams { get; set; }
}