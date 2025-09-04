using System.Security.AccessControl;
using sigur_emulation.Dto;
using AccessRule = sigur_emulation.Models.AccessRule;

namespace sigur_emulation.Interfaces;

public interface IAccessRuleService
{
    Task CreateAccessRule(int employeeId, int roleId);
    Task DeleteAccessRule(int employeeId, int roleId);
    Task<List<GetAccessRuleDto>>GetEmployeeAccessAsync(int[] employeeIds);
}