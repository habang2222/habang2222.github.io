namespace EveRemote.Core.Configuration;

/// <summary>Configures the low-frequency local EVE window discovery loop.</summary>
public sealed class EveOptions
{
    public const string SectionName = "Eve";
    public string[] ProcessNames { get; init; } = ["exefile", "eve"];
    public int DiscoveryIntervalMs { get; init; } = 2000;
}
