using System.Text.Json.Serialization;

/// <summary>
/// Модель Sigur для авторизации.
/// </summary>
public class SigurAuth
{
    /// <summary>
    /// Токен авторизации.
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; }

    /// <summary>
    /// Токен обновления авторизации.
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Срок годности токена.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Срок годности токен обновления.
    /// </summary>
    [JsonPropertyName("refreshExpiresAt")]
    public DateTime? RefreshExpiresAt { get; set; }
}