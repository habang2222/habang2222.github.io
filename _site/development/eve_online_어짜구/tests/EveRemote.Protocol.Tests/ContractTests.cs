using EveRemote.Protocol.V1;
using Google.Protobuf;
namespace EveRemote.Protocol.Tests;

public sealed class ContractTests
{
    [Fact]
    public void StatusReplyRoundTripsClientIdentity()
    {
        var source = new AgentStatusReply { AgentId = "a", MachineName = "pc" };
        source.Clients.Add(new EveClientStatus { ClientId = "12:AB", ProcessId = 12 });
        AgentStatusReply clone = AgentStatusReply.Parser.ParseFrom(source.ToByteArray());
        Assert.Equal("12:AB", clone.Clients.Single().ClientId);
    }
}
