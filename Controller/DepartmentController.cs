using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;
using sigur_emulation.Models;

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
    public async Task<IActionResult> GetAllDepartments([FromQuery] Pagination query)
    {
        var limit = query.Limit ?? 5; 
        var offset = query.Offset ?? 0; 
        
        var departments = await _departmentService.GetAllAsync(limit, offset); 
        
        return Ok(departments);
    }
}