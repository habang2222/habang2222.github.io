using EveRemote.Core.Models;
namespace EveRemote.Agent.Services;

public sealed class AgentSnapshotStore(string agentId) : IAgentSnapshotStore
{
    private AgentSnapshot _current = AgentSnapshot.Empty(agentId, Environment.MachineName);
    public AgentSnapshot Current => Volatile.Read(ref _current);
    public void Update(AgentSnapshot snapshot) => Volatile.Write(ref _current, snapshot);
}
