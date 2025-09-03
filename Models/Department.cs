using System.Text.Json.Serialization;

namespace sigur_emulation.Models;

public class Department
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    [JsonIgnore]
    public Department Parent { get; set; }
    public string Name { get; set; }
}