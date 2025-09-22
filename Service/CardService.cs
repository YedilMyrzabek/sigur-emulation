using Microsoft.EntityFrameworkCore;
using sigur_emulation.Data;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Repository;

public class CardService : ICardService
{
    private readonly ApplicationDbContext _context;

    public CardService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Card>> GetAllAsync(int offset, int limit)
    {
        return await _context.Cards
            .Include(c => c.Holder)
            .Skip(offset * limit)
            .Take(limit)
            .ToListAsync();
    }
}