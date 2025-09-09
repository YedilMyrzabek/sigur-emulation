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
            Format = cardModel.Format,
            Holder = cardModel.Holder,
            GuestApplicable = cardModel.GuestApplicable,
            MfUid = cardModel.MfUid
        };
    }
}