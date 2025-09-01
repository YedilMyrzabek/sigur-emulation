using System.ComponentModel.DataAnnotations;

namespace sigur_emulation.Dto;

public class PersonnelDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? OrganizationId { get; set; }
    public Guid? StructuralUnitId { get; set; }
    [Required]
    public int ExternalId { get; set; }
    [Required]
    public string TabulatedNumber { get; set; }
    public bool? IsUnderground { get; set; }
}