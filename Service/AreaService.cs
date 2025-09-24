using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigur_emulation.Data;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Repository;

public class AreaService : IAreaService
{
    private readonly ApplicationDbContext _context;
    
    public AreaService(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Area>> GetAllAsync(int limit, int offset)
    {
        return await _context.Areas
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }
}