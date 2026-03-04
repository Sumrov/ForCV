namespace EslOnline.Infrastructure.Configuration;

public sealed class DatabaseOptions
{
    public const string SectionName = "ConnectionStrings";

    // Имя свойства должно совпадать с ключом в appsettings.json (обычно "Default")
    public string Default { get; set; } = string.Empty;
}