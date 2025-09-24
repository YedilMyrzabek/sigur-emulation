using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;

namespace sigur_emulation.Controller;

[Route("api")]
[ApiController]
public class AreaController : ControllerBase
{
    private readonly IAreaService _areaService;

    public AreaController(IAreaService areaService)
    {
        _areaService = areaService;
    }

    [HttpGet("area")]
    public async Task<IActionResult> GetAllAreas([FromQuery] int  limit, int offset)
    {
        var structuralUnits = await _areaService.GetAllAsync(limit, offset);
        
        return Ok(structuralUnits);
    }
}
