using System.Text.Json.Serialization;

namespace API.Data.Auth0;

public class Auth0Token
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }
}
