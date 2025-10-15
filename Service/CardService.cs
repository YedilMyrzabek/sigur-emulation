using Microsoft.EntityFrameworkCore;
using sigur_emulation.Data;
using sigur_emulation.Dto;
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
    
    public async Task<List<Card>> GetAllAsync(int limit, int offset)
    {
        return await _context.Cards
            .Include(c => c.Holder)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Card>> GetEmployeeCardAsync(
        List<int> employeeIds, 
        List<int>? cardIds, 
        int limit, 
        int offset)
    {

        var query = _context.Cards
            .Include(c => c.Holder)
            .AsQueryable();

        if (employeeIds is { Count: > 0 })
        {
            query = query.Where(c => c.Holder != null && employeeIds.Contains(c.Holder.HolderId));
        }

        if (cardIds is { Count: > 0 })
        {
            query = query.Where(c => cardIds.Contains(c.Id));
        }
        
        var result  = await query
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
        
        return result;
    }
}