using EveRemote.Agent.Services;
using EveRemote.Core.Abstractions;
using EveRemote.Core.Configuration;
using EveRemote.Infrastructure.Windows;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(builder.Configuration.GetValue("Agent:Port", 5081), listen =>
        listen.Protocols = HttpProtocols.Http2);
});
builder.Services.AddGrpc();
builder.Services.Configure<EveOptions>(builder.Configuration.GetSection(EveOptions.SectionName));
builder.Services.AddSingleton<IProcessWindowSource, SystemProcessWindowSource>();
builder.Services.AddSingleton<IEveWindowDiscovery, EveWindowDiscovery>();
builder.Services.AddSingleton<IAgentSnapshotStore>(_ =>
    new AgentSnapshotStore(builder.Configuration["Agent:Id"] ?? Environment.MachineName));
builder.Services.AddHostedService<DiscoveryWorker>();

WebApplication app = builder.Build();
app.MapGrpcService<AgentStatusGrpcService>();
app.MapGet("/", () => "EveRemote.Agent gRPC endpoint");
await app.RunAsync();
