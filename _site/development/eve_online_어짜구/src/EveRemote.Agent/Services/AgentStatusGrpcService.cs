using EveRemote.Core.Models;
using EveRemote.Protocol.V1;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
namespace EveRemote.Agent.Services;

/// <summary>Exposes read-only Stage 1 status. No input RPC is mapped.</summary>
public sealed class AgentStatusGrpcService(IAgentSnapshotStore store) : AgentStatus.AgentStatusBase
{
    public override Task<AgentStatusReply> GetSnapshot(AgentStatusRequest request, ServerCallContext context)
    {
        AgentSnapshot snapshot = store.Current;
        var reply = new AgentStatusReply
        {
            AgentId = snapshot.AgentId,
            MachineName = snapshot.MachineName,
            ObservedAtUtc = Timestamp.FromDateTimeOffset(snapshot.ObservedAtUtc),
        };
        reply.Clients.AddRange(snapshot.Clients.Select(static client => new EveClientStatus
        {
            ClientId = client.ClientId,
            ProcessId = client.ProcessId,
            WindowHandle = client.WindowHandle,
            WindowTitle = client.WindowTitle,
            ClientWidth = client.ClientWidth,
            ClientHeight = client.ClientHeight,
            IsMinimized = client.IsMinimized,
        }));
        return Task.FromResult(reply);
    }

    public override Task<HeartbeatReply> Heartbeat(HeartbeatRequest request, ServerCallContext context) =>
        Task.FromResult(new HeartbeatReply { ReceivedAtUtc = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow) });
}
