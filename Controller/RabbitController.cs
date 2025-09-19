using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Models;

namespace sigur_emulation.Controller;

[Route("api/v1")]
[ApiController]
public class RabbitController : ControllerBase
{
    private readonly IRabbitService _rabbitService;

    public RabbitController(IRabbitService rabbitService)
    {
        _rabbitService = rabbitService;
    }

    [HttpPost("alco-message")]
    public async Task<IActionResult> Send([FromBody] AlcoMessage message)
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