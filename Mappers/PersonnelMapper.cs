using sigur_emulation.Dto;
using sigur_emulation.Models;

namespace sigur_emulation.Mappers;

public static class PersonnelMapper
{
    public static PersonnelDto ToPersonnelDto(this Personnel personnelModel)
    {
        return new PersonnelDto
        {
            Id = personnelModel.Id,
            FirstName = personnelModel.FirstName,
            LastName = personnelModel.LastName,
            MiddleName = personnelModel.MiddleName,
            PositionId = personnelModel.PositionId,
            OrganizationId = personnelModel.OrganizationId,
            StructuralUnitId = personnelModel.StructuralUnitId,
            ExternalId = personnelModel.ExternalId,
            TabulatedNumber = personnelModel.TabulatedNumber,
            IsUnderground = personnelModel.IsUnderground
        };
    }
}