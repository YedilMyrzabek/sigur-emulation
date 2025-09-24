using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Controller;

[Route("/api/v1")]
[ApiController]
public class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;
    
    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpGet("positions")]
    public async Task<IActionResult> GetAllPositions([FromQuery] Pagination query)
    {
        var limit = query.Limit ?? 100; 
        var offset = query.Offset ?? 0; 
        
        var positions = await _positionService.GetAllAsync(limit, offset);

        return Ok(positions);
    }
}