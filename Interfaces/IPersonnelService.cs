using sigur_emulation.Models;

namespace sigur_emulation.Interfaces;

public interface IPersonnelService
{
    Task<List<Personnel>> GetAllAsync();
}