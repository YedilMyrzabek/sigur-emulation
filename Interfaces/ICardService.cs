using sigur_emulation.Dto;
using sigur_emulation.Models;
using sigur_emulation.Repository;

namespace sigur_emulation.Interfaces;

public interface ICardService
{
    Task<List<Card>> GetAllAsync(int limit, int offset);
    Task<IEnumerable<Card>> GetEmployeeCardAsync(
        List<int> employeeIds,
        List<int>? cardIds,
        int limit,
        int offset);
}