namespace sigur_emulation.Models;

public class StructuralUnit
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public Guid? ParentId { get; set; }
    public StructuralUnit Parent { get; set; }
    public ICollection<StructuralUnit> Children { get; set; } = new List<StructuralUnit>();

    public Dictionary<string, string> Name { get; set; } 
    public Dictionary<string, string>? ShortName { get; set; }
    public int? ExternalId { get; set; }
}