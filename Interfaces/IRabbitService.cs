using sigur_emulation.Models;

namespace sigur_emulation.Interfaces;

public interface IRabbitService
{
    Task SendMessage<T>(T message);
}