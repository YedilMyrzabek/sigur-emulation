using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sigur_emulation.Data;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Repository;

public class StructuralUnitService : IStructuralUnit
{
    private readonly ApplicationDbContext _context;
    
    public StructuralUnitService(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<StructuralUnit>> GetAllAsync()
    {
        return await _context.StructuralUnits
            .Include(o => o.Organization)
            .ToListAsync();
    }
}