using sigur_emulation.Dto;
using sigur_emulation.Models;

namespace sigur_emulation.Mappers;

public static class OrganizationMapper
{
    public static OrganizationDto ToOrganizationDto(this Organization organizationModel)
    {
        return new OrganizationDto
        {
            Id = organizationModel.Id,
            ParentId = organizationModel.ParentId,
            Name = organizationModel.Name,
            ShortName = organizationModel.ShortName,
            ExternalId = organizationModel.ExternalId
        };
    }
}