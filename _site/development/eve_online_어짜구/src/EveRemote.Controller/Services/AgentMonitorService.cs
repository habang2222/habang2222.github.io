using EveRemote.Protocol.V1;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
namespace EveRemote.Controller.Services;

public sealed class AgentMonitorService : IDisposable
{
    private readonly IReadOnlyList<AgentEndpoint> _endpoints;
    private readonly IReadOnlyDictionary<string, GrpcChannel> _channels;

    public AgentMonitorService(IConfiguration configuration)
    {
        _endpoints = configuration.GetSection("Controller:Agents").GetChildren()
            .Select(section => new AgentEndpoint(section["Name"] ?? "Agent",
                section["Address"] ?? throw new InvalidOperationException("Agent Address is required."))).ToArray();
        _channels = _endpoints.Select(static endpoint => endpoint.Address)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToDictionary(static address => address, GrpcChannel.ForAddress, StringComparer.OrdinalIgnoreCase);
    }

    public IReadOnlyList<AgentEndpoint> Endpoints => _endpoints;

    public async Task<AgentPollResult> PollAsync(AgentEndpoint endpoint, CancellationToken cancellationToken)
    {
        var client = new AgentStatus.AgentStatusClient(_channels[endpoint.Address]);
        DateTimeOffset started = DateTimeOffset.UtcNow;
        AgentStatusReply reply = await client.GetSnapshotAsync(new AgentStatusRequest { ControllerId = Environment.MachineName },
            deadline: DateTime.UtcNow.AddSeconds(2), cancellationToken: cancellationToken);
        return new(endpoint, reply, DateTimeOffset.UtcNow - started);
    }

    public void Dispose()
    {
        foreach (GrpcChannel channel in _channels.Values) channel.Dispose();
    }
}
public sealed record AgentEndpoint(string Name, string Address);
public sealed record AgentPollResult(AgentEndpoint Endpoint, AgentStatusReply Reply, TimeSpan Latency);
