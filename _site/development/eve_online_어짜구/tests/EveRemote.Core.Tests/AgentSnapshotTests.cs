using EveRemote.Core.Models;
namespace EveRemote.Core.Tests;

public sealed class AgentSnapshotTests
{
    [Fact]
    public void EmptyHasNoClientsAndKeepsIdentity()
    {
        AgentSnapshot snapshot = AgentSnapshot.Empty("agent-1", "pc-1");
        Assert.Equal("agent-1", snapshot.AgentId);
        Assert.Equal("pc-1", snapshot.MachineName);
        Assert.Empty(snapshot.Clients);
    }
}
