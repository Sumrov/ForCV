namespace EslOnline.Application.Configurations;

public sealed class GameBalance
{
    public const string SectionName = "GameBalance";
    public int MaxPopulationPerCity { get; init; } = 1000;
}