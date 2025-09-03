using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;

namespace sigur_emulation.Controller;

[Route("api/[controller]")]
[ApiController]
public class RabbitController : ControllerBase
{
    private readonly IRabbitService _rabbitService;

    public RabbitController(IRabbitService rabbitService)
    {
        _rabbitService = rabbitService;
    }

    [HttpPost]
    public async Task<IActionResult> Send([FromBody] string message)
    {
        await _rabbitService.SendMessage(message);
        return Ok("Message sent");
        
        //AccessPointId=20,
        //Direction=21,
        //EmployeeId=4444444,
        //TabNumber=666666,
        //Timestamp=2025-04-01T12:34:56.789,
        //Ppm=13232,
        //Type=1
    }
}