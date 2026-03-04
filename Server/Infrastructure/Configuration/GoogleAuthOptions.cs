namespace EslOnline.Infrastructure.Configuration;

public sealed class GoogleAuthOptions
{
    public const string SectionName = "Authentication";
    public string GoogleRedirectURL { get; set; } = string.Empty;
    public string GoogleUserInfoURL { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
    public GoogleSubOptions Google { get; set; } = new();
}

public class GoogleSubOptions
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}


