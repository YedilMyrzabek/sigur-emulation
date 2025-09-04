using System.ComponentModel.DataAnnotations;

namespace sigur_emulation.Dto;

public class GetAccessRuleDto
{
    [Required] public int EmployeeId { get; set; }
    [Required] public List<int> AccessruleIds { get; set; }
}