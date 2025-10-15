using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;
using sigur_emulation.Models;

namespace sigur_emulation.Controller;

[ApiController]
[Route("/api/v1")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("cards")]
    public async Task<IActionResult> GetAllCards([FromQuery] Pagination query)
    {
        var limit = query.Limit ?? 100; 
        var offset = query.Offset ?? 0; 
        
        var cards = await _cardService.GetAllAsync(limit, offset);
        
        var cardDto = cards.Select(c => c.ToCardDto());

        return Ok(cardDto);
    }

    [HttpGet("bindings/employees-cards")]
    public async Task<IActionResult> GetEmployeeCard(
        [FromQuery(Name = "employeeId")] List<int> employeeIds,
        [FromQuery(Name = "cardId")] List<int>? cardIds,
        [FromQuery] Pagination query)
    {
        var limit = query.Limit ?? 100; 
        var offset = query.Offset ?? 0;
        
        var cards = await _cardService.GetEmployeeCardAsync(employeeIds, cardIds, limit, offset);
        
        var cardDto = cards.Select(c => c.ToEmployeeCardDto());

        return Ok(cardDto);
    }
}