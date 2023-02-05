namespace API.Data.Configuration;

public sealed class Auth0Options
{
    public string? Authority { get; set; }
    public string? Audience { get; set; }
    public string? APIClientID { get; set; }
    public string? APIClientSecret { get; set; }
    public string? APIAudience { get; set; }
    public string? APIGrantType { get; set; }
    public string? APIRootURL { get; set; }
}
