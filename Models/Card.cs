namespace sigur_emulation.Models;

public class Card
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public string FormattedValue { get; set; }
    public string Format { get; set; }
    public int? CardHolderId { get; set; }
    public CardHolder? Holder { get; set; }
    public bool GuestApplicable { get; set; }
    public string? MfUid { get; set; }
}