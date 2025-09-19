using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;

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
    public async Task<IActionResult> GetAllCards()
    {
        var cards = await _cardService.GetAllAsync();

        if (cards == null)
            return NotFound("Card not found!");

        var cardDto = cards.Select(c => c.ToCardDto());

        return Ok(cardDto);
    }
}