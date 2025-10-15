namespace sigur_emulation.Dto;

public class EmployeeCardDto
{
    public int EmployeeId { get; set; }
    public int CardId { get; set; }
    public string? Format { get; set; }
    public string? StartDate { get; set; }
    public string? ExpirationDate { get; set; }
}