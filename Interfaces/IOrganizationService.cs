using sigur_emulation.Models;

namespace sigur_emulation.Interfaces;

public interface IOrganizationService
{
    Task<List<Organization>> GetAllAsync();
}