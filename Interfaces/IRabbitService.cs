namespace sigur_emulation.Interfaces;

public interface IRabbitService
{
    Task SendMessage(string message);
}