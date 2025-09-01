using Microsoft.EntityFrameworkCore;
using sigur_emulation.Data;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Repository;

public class PersonnelService : IPersonnelService
{
    private readonly ApplicationDbContext _context;

    public PersonnelService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Personnel>> GetAllAsync()
    {
        return await _context.Personnels
            .Include(p => p.Position)
            .Include(p => p.Organization)
            .Include(p => p.StructuralUnit)
            .ToListAsync();
    }
}