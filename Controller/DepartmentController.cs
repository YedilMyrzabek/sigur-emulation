using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;

namespace sigur_emulation.Controller;

[Route("/api/v1")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("departments")]
    public async Task<IActionResult> GetAllDepartments()
    {
        var organizatoins = await _departmentService.GetAllAsync();

        if (organizatoins == null)
            return NotFound("Organization not found!!!!!");
        
        return Ok(organizatoins);
    }
}