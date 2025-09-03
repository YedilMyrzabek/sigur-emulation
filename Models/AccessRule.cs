using System.Security.AccessControl;

namespace sigur_emulation.Models;

public class AccessRule
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Personnel Employee { get; set; }
    public int AccessRuleId { get; set; }
    
}