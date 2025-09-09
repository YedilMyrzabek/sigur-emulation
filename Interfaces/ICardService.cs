using sigur_emulation.Models;
using sigur_emulation.Repository;

namespace sigur_emulation.Interfaces;

public interface ICardService
{
    Task<List<Card>> GetAllAsync();
}