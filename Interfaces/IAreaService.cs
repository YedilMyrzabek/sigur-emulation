using sigur_emulation.Models;

namespace sigur_emulation.Interfaces;

public interface IAreaService
{
    Task<List<Area>> GetAllAsync();
}