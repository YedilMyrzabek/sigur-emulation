using sigur_emulation.Models;

namespace sigur_emulation.Interfaces;

public interface IPositionService
{
    Task<List<Position>> GetAllAsync();
}