using System.Text.Json.Serialization;

namespace sigur_emulation.Models;

public class Organization
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? ParentId { get; set; }
    [JsonIgnore]
    public Organization Parent { get; set; }
    public ICollection<Organization> Children { get; set; } = new List<Organization>();
    public Dictionary<string,string> Name { get; set; }
    public Dictionary<string, string> ShortName { get; set; }
    public int ExternalId { get; set; }
    public ICollection<StructuralUnit>? StructuralUnits { get; set; } = new List<StructuralUnit>();
}