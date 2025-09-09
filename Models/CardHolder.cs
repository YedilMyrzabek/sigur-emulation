using System.Text.Json.Serialization;

namespace sigur_emulation.Models;

public class CardHolder
{
    public int HolderId { get; set; }
    public string Type { get; set; }
    [JsonIgnore]
    public Personnel Personnel { get; set; }
}