using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;

namespace sigur_emulation.Controller;

[Route("api/[controller]")]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _organizationService;
    
    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrganizations()
    {
        var organizatoins = await _organizationService.GetAllAsync();

        if (organizatoins == null)
            return NotFound("Organization not found!!!!!");
        
        var organizationDto = organizatoins.Select(o => o.ToOrganizationDto());
        
        return Ok(organizationDto);
    }
}