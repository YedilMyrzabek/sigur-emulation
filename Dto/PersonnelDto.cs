using System.ComponentModel.DataAnnotations;
using sigur_emulation.Models;

namespace sigur_emulation.Dto;

public class PersonnelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public int? PositionId { get; set; }
    public string? PositionName { get; set; }
    public string? Photo { get; set; }
    public string? TabId { get; set; }
    public string? AreaId { get; set; }
    public string? MainDepartmentId { get; set; }
}