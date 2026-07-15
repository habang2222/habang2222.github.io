namespace EveRemote.Core.Models;

/// <summary>Immutable current state reported by one agent.</summary>
public sealed record AgentSnapshot(string AgentId, string MachineName, DateTimeOffset ObservedAtUtc,
    IReadOnlyList<EveClientInfo> Clients)
{
    /// <summary>Creates an empty initial snapshot.</summary>
    public static AgentSnapshot Empty(string agentId, string machineName) =>
        new(agentId, machineName, DateTimeOffset.UtcNow, []);
}
