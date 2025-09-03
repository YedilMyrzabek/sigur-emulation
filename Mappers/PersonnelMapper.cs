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
            Name = personnelModel.Name,
            DepartmentId = personnelModel.DepartmentId,
            DepartmentName = personnelModel.Department?.Name,
            PositionId = personnelModel.PositionId,
            PositionName = personnelModel.Position?.Name,
            Photo = personnelModel.Photo,
            TabId =  personnelModel.TabId,
            AreaId = personnelModel.AreaId,
            MainDepartmentId = personnelModel.DepartmentId,
        };
    }
}