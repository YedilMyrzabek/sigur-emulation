using Microsoft.EntityFrameworkCore;
using sigur_emulation.Data;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Repository;

public class PositionService : IPositionService
{
    private readonly ApplicationDbContext _context;
    
    public PositionService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Position>> GetAllAsync(int limit, int offset)
    {
        return await _context.Positions
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }
}