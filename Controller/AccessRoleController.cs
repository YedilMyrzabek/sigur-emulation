using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Dto;
using sigur_emulation.Interfaces;

namespace sigur_emulation.Controller;

[Route("/api/v1/bindings")]
[ApiController]
public class AccessRoleController : ControllerBase
{
    private readonly IAccessRuleService _accessRuleService;

    public AccessRoleController(IAccessRuleService accessRuleService)
    {
        _accessRuleService = accessRuleService;
    }

    [HttpPost("employees-accessrules")]
    public async Task<IActionResult> CreateAccessRole([FromBody] AccessRuleDto dto)
    {
        if (dto.EmployeeId <= 0 || dto.AccessruleId <= 0)
        {
            return BadRequest("Employee Id or Role Id is invalid");
        }
        
        await _accessRuleService.CreateAccessRule(dto.EmployeeId, dto.AccessruleId); 
        return Ok();
    }

    [HttpDelete("employees-accessrules/delete")]
    public async Task<IActionResult> DeleteAccessRole([FromBody] AccessRuleDto dto)
    {
        if (dto.EmployeeId <= 0 || dto.AccessruleId <= 0)
        {
            return BadRequest("Employee Id or Role Id is invalid");
        }
        
        await _accessRuleService.DeleteAccessRule(dto.EmployeeId, dto.AccessruleId);
        return Ok();
    }

    [HttpGet("employees-accessrules")]
    public async Task<IActionResult> GetEmployeeAccessAsync([FromQuery] int[] employeeIds)
    {
        var accessRules = await _accessRuleService.GetEmployeeAccessAsync(employeeIds);
        
        return Ok(new
        {
            AccessrulesIds = accessRules.ToDictionary(
            ac => ac.Key,
            ac => ac.Value.ToArray())
        });
    }
}