using sigur_emulation.Dto;
using sigur_emulation.Models;

namespace sigur_emulation.Mappers;

public static class CardMapper
{
    public static CardDto ToCardDto(this Card cardModel)
    {
        return new CardDto
        {
            Id = cardModel.Id,
            Name = cardModel.Name,
            Value = cardModel.Value,
            FormattedValue = cardModel.FormattedValue,
            Format = cardModel.Format?.ToString(),
            Holder = cardModel.Holder,
            GuestApplicable = cardModel.GuestApplicable,
            MfUid = cardModel.MfUid
        };
    }

    public static EmployeeCardDto ToEmployeeCardDto(this Card cardModel)
    {
        return new EmployeeCardDto()
        {
            EmployeeId = cardModel.Holder!.HolderId,
            CardId = cardModel.Id,
            Format = cardModel.Format?.ToString(),
            StartDate = null,
            ExpirationDate = null
        };
    }
}