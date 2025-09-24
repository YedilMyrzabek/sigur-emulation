using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;
using sigur_emulation.Models;

namespace sigur_emulation.Controller;

[Route("/api/v1")]
[ApiController]
public class PersonnelController : ControllerBase
{
    private readonly IPersonnelService _personnelService;
    
    public PersonnelController(IPersonnelService personnelService)
    {
        _personnelService = personnelService;
    }
    
    [HttpGet("employees")]
    public async Task<IActionResult> GetAllPersonnels([FromQuery] Pagination query)
    {
        var limit = query.Limit ?? 100; 
        var offset = query.Offset ?? 0; 
        
        var personnel = await _personnelService.GetAllAsync(limit, offset);

        var personnelDto = personnel.Select(p => p.ToPersonnelDto());

        return Ok(personnelDto);
    }
}