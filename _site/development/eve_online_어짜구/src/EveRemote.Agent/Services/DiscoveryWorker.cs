using EveRemote.Core.Abstractions;
using EveRemote.Core.Configuration;
using EveRemote.Core.Models;
using Microsoft.Extensions.Options;
namespace EveRemote.Agent.Services;

public sealed class DiscoveryWorker(IEveWindowDiscovery discovery, IAgentSnapshotStore store,
    IOptions<EveOptions> options, ILogger<DiscoveryWorker> logger) : BackgroundService
{
    private static readonly Action<ILogger, Exception?> LogDiscoveryPassFailure = LoggerMessage.Define(
        LogLevel.Error, new EventId(1, nameof(LogDiscoveryPassFailure)), "EVE window discovery pass failed");
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int interval = Math.Clamp(options.Value.DiscoveryIntervalMs, 500, 60_000);
        using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(interval));
        try
        {
            do
            {
                try
                {
                    IReadOnlyList<EveClientInfo> clients = await discovery.DiscoverAsync(stoppingToken);
                    AgentSnapshot previous = store.Current;
                    store.Update(new(previous.AgentId, previous.MachineName, DateTimeOffset.UtcNow, clients));
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) { break; }
                catch (Exception exception) { LogDiscoveryPassFailure(logger, exception); }
            }
            while (await timer.WaitForNextTickAsync(stoppingToken));
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // Expected during service shutdown.
        }
    }
}
