namespace sigur_emulation.Models;

public class Personnel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Guid? PositionId { get; set; }
    public Position Position { get; set; }
    public Guid? OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public Guid? StructuralUnitId { get; set; }
    public StructuralUnit StructuralUnit { get; set; }
    public int ExternalId { get; set; }
    public string TabulatedNumber { get; set; }
    public bool? IsUnderground { get; set; }
}