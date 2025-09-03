using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using sigur_emulation.Data;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;
using AccessRule = sigur_emulation.Models.AccessRule;

namespace sigur_emulation.Repository;

public class AccessRuleService : IAccessRuleService
{
    private readonly ApplicationDbContext _context;

    public AccessRuleService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateAccessRule(int employeeId, int roleId)
    {
        var employeeExists = await _context.Personnels
            .AnyAsync(e => e.Id == employeeId);
        
        if (!employeeExists)
        {
            throw new ArgumentException($"Personnel: {employeeId} not found");
        }
        
        var exist = await _context.AccessRules
            .AnyAsync(acr => acr.EmployeeId == employeeId && acr.AccessRuleId == roleId);
        
        if (!exist)
        {
            _context.AccessRules.Add(new AccessRule
            {
                EmployeeId = employeeId,
                AccessRuleId = roleId
            });
            
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAccessRule(int employeeId, int roleId)
    {
        var employeeExists = await _context.Personnels
            .AnyAsync(e => e.Id == employeeId);

        if (!employeeExists)
        {
            throw new ArgumentException($"Personnel: {employeeId} not found");
        }

        var entity = await _context.AccessRules
            .FirstOrDefaultAsync(acr => acr.EmployeeId == employeeId && acr.AccessRuleId == roleId);

        if (entity != null)
        {
            _context.AccessRules.Remove(entity);
            await _context.SaveChangesAsync();
        }    
    }

    public async Task<Dictionary<int, IEnumerable<int>>> GetEmployeeAccessAsync(int[] employeeIds)
    {
        var existingEmployeeIds = await _context.AccessRules
            .Where(p => employeeIds.Contains(p.EmployeeId))
            .Select(p => p.EmployeeId)
            .ToListAsync();
        
        var notFoundEmployees = employeeIds.Except(existingEmployeeIds).ToList();
        if (notFoundEmployees.Any())
        {
            throw new Exception($"Personnel not found: {string.Join(", ", notFoundEmployees)}");
        }
        
        var accessRules = await _context.AccessRules
            .Where(ar => employeeIds.Contains(ar.EmployeeId))
            .Select(ar => new { ar.EmployeeId, ar.AccessRuleId })
            .ToListAsync();
        
        var result = employeeIds.ToDictionary(
            employeeId => employeeId,
            employeeId => accessRules
                .Where(ar => ar.EmployeeId == employeeId)
                .Select(ar => ar.AccessRuleId)
                .AsEnumerable()
        );
            
        return result;
    }
}