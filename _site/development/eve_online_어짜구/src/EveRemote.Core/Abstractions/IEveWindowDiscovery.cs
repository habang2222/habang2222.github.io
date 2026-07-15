using EveRemote.Core.Models;
namespace EveRemote.Core.Abstractions;

/// <summary>Discovers visible local EVE windows without reading game memory.</summary>
public interface IEveWindowDiscovery
{
    ValueTask<IReadOnlyList<EveClientInfo>> DiscoverAsync(CancellationToken cancellationToken);
}
