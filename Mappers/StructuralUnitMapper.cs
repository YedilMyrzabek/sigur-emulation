using sigur_emulation.Dto;
using sigur_emulation.Models;

namespace sigur_emulation.Mappers;

public static class StructuralUnitMapper
{
    public static StructuralUnitDto ToStructuralUnitDto(this StructuralUnit structuralUnitModel)
    {
        return new StructuralUnitDto
        {
            Id = structuralUnitModel.Id,
            ParentId = structuralUnitModel.ParentId,
            OrganizationId = structuralUnitModel.OrganizationId,
            Name = structuralUnitModel.Name,
            ShortName = structuralUnitModel.ShortName,
            ExternalId = structuralUnitModel.ExternalId
        };
    }
}