namespace sigur_emulation.Models;

public class AlcoMessage
{
    public int? EmployeeId { get; set; }
    public int? AccessPointId { get; set; }
    public int? Type { get; set; }
    public object? Ppm { get; set; }
    public int? DepartmentExternalId { get; set; }
    public string? TabNumber { get; set; }
    public string? Timestamp { get; set; }
    public int? Direction { get; set; }
}