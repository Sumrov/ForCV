namespace EslOnline.Infrastructure.Configuration;

public sealed class JwtOptions
{
    public const string SectionName = "JwtSettings";

    public string BearerKey { get; set; } = string.Empty;

    // Время жизни токена
    public JwtTokenLifeOptions JwtTokenLife { get; set; } = new();

    // Полезно добавить эти поля, чтобы валидировать токен правильно
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}

public class JwtTokenLifeOptions
{
    public int Hours { get; set; } = 24; // Значение по умолчанию
}
