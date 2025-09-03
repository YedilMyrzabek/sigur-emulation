using System.Security.AccessControl;
using AccessRule = sigur_emulation.Models.AccessRule;

namespace sigur_emulation.Interfaces;

public interface IAccessRuleService
{
    Task CreateAccessRule(int employeeId, int roleId);
    Task DeleteAccessRule(int employeeId, int roleId);
    Task<Dictionary<int, IEnumerable<int>>> GetEmployeeAccessAsync(int[] employeeIds);
}