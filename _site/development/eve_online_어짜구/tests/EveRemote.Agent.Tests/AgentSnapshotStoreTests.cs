using EveRemote.Agent.Services;
using EveRemote.Core.Models;
namespace EveRemote.Agent.Tests;

public sealed class AgentSnapshotStoreTests
{
    [Fact]
    public void UpdateReplacesWholeSnapshotAtomically()
    {
        var store = new AgentSnapshotStore("agent-1");
        var expected = new AgentSnapshot("agent-1", "pc", DateTimeOffset.UtcNow, []);
        store.Update(expected);
        Assert.Same(expected, store.Current);
    }
}
