namespace sigur_emulation.Models;

public class Personnel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? DepartmentId { get; set; }
    public Department Department { get; set; }
    public int? PositionId { get; set; }
    public Position Position { get; set; }
    public string? Photo { get; set; }
    public string TabId { get; set; }
    public string? AreaId { get; set; }
    public Area Area { get; set; }
    public string? MainDepartmentId { get; set; }
}