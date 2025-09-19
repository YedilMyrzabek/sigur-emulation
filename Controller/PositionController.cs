using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;

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
    public async Task<IActionResult> GetAllPositions()
    {
        var positions = await _positionService.GetAllAsync();
        
        if (positions == null)
            return NotFound("Positions not found!!!!!");

        return Ok(positions);
    }
}