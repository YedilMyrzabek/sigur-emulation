using System.ComponentModel.DataAnnotations;

namespace sigur_emulation.Dto;

public class StructuralUnitDto
{
    public Guid Id { get; set; }
    public Guid? OrganizationId { get; set; }
    public Guid? ParentId { get; set; }
    public Dictionary<string, string> Name { get; set; } 
    public Dictionary<string, string>? ShortName { get; set; }
    [Required]
    public int? ExternalId { get; set; }
}