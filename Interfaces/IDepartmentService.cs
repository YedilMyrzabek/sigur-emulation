using sigur_emulation.Models;

namespace sigur_emulation.Interfaces;

public interface IDepartmentService
{
    Task<List<Department>> GetAllAsync(int limit, int offset);
}