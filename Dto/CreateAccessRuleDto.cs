using System.ComponentModel.DataAnnotations;

namespace sigur_emulation.Dto;

public class CreateAccessRuleDto
{
    [Required] 
    public int EmployeeId { get; set; }
    
    [Required] 
    public int AccessruleId { get; set; }
}