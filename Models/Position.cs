namespace sigur_emulation.Models;

public class Position
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Dictionary<string, string> Name { get; set; }
    public Dictionary<string, string> ShortName { get; set; }
    public int ExternalId { get; set; }
}