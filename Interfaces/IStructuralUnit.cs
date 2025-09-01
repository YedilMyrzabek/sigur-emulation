using sigur_emulation.Models;

namespace sigur_emulation.Interfaces;

public interface IStructuralUnit
{
    Task<List<StructuralUnit>> GetAllAsync();
}