using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Interfaces;
using sigur_emulation.Mappers;

namespace sigur_emulation.Controller;

[Route("api/[controller]")]
[ApiController]
public class StructuralUnitController : ControllerBase
{
    private readonly IStructuralUnit _structuralUnit;

    public StructuralUnitController(IStructuralUnit structuralUnit)
    {
        _structuralUnit = structuralUnit;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStructuralUnit()
    {
        var structuralUnits = await _structuralUnit.GetAllAsync();
        
        if (structuralUnits == null)
            return NotFound("StructuralUnits not found!!!!!");

        var structuralUnitsDto = structuralUnits.Select(st => st.ToStructuralUnitDto());

        return Ok(structuralUnitsDto);
    }
}
