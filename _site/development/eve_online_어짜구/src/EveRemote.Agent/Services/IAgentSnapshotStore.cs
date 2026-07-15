using EveRemote.Core.Models;
namespace EveRemote.Agent.Services;

/// <summary>Provides the most recent immutable discovery result.</summary>
public interface IAgentSnapshotStore
{
    AgentSnapshot Current { get; }
    void Update(AgentSnapshot snapshot);
}
