using sigur_emulation.Models;

namespace sigur_emulation.Dto;

public class CardDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public string FormattedValue { get; set; }
    public string Format { get; set; }
    public CardHolder? Holder { get; set; }
    public bool GuestApplicable { get; set; }
    public string? MfUid { get; set; }
}