using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;

namespace sigur_emulation.Controller;

[Route("api/[controller]")]
[ApiController]
public class PersonnelController : ControllerBase
{
    private readonly IPersonnelService _personnelService;
    
    public PersonnelController(IPersonnelService personnelService)
    {
        _personnelService = personnelService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPersonnels()
    {
        var personnel = await _personnelService.GetAllAsync();

        if (personnel == null)
            return StatusCode(500, "Error: NULL");

        var personnelDto = personnel.Select(p => p.ToPersonnelDto());

        return Ok(personnelDto);
    }
}