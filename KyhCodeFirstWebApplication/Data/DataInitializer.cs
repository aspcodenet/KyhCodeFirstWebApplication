﻿using Microsoft.EntityFrameworkCore;

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
    }
}