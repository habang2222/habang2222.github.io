using EveRemote.Core.Abstractions;
using EveRemote.Core.Configuration;
using EveRemote.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace EveRemote.Infrastructure.Windows;

public sealed class EveWindowDiscovery(IProcessWindowSource source, IOptions<EveOptions> options,
    ILogger<EveWindowDiscovery> logger) : IEveWindowDiscovery
{
    private static readonly Action<ILogger, string, Exception?> LogDiscoveryFailure = LoggerMessage.Define<string>(
        LogLevel.Warning, new EventId(1, nameof(LogDiscoveryFailure)),
        "EVE process discovery failed for {ProcessName}");
    private readonly string[] _processNames = options.Value.ProcessNames
        .Where(static name => !string.IsNullOrWhiteSpace(name))
        .Select(static name => Path.GetFileNameWithoutExtension(name.Trim()))
        .Distinct(StringComparer.OrdinalIgnoreCase).ToArray();

    public ValueTask<IReadOnlyList<EveClientInfo>> DiscoverAsync(CancellationToken cancellationToken)
    {
        var clients = new List<EveClientInfo>(4);
        DateTimeOffset observedAt = DateTimeOffset.UtcNow;
        string agentId = Environment.MachineName;
        foreach (string processName in _processNames)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                foreach (ProcessWindowSnapshot process in source.GetByProcessName(processName))
                {
                    if (process.MainWindowHandle == nint.Zero) continue;
                    bool hasRect = User32.GetClientRect(process.MainWindowHandle, out User32.Rect rect);
                    int width = hasRect ? Math.Max(0, rect.Right - rect.Left) : 0;
                    int height = hasRect ? Math.Max(0, rect.Bottom - rect.Top) : 0;
                    string id = $"{process.ProcessId}:{process.MainWindowHandle.ToInt64():X}";
                    clients.Add(new(agentId, id, process.ProcessId, process.MainWindowHandle.ToInt64(),
                        process.MainWindowTitle, width, height, User32.IsIconic(process.MainWindowHandle), observedAt));
                }
            }
            catch (Exception exception) when (exception is InvalidOperationException or System.ComponentModel.Win32Exception)
            {
                LogDiscoveryFailure(logger, processName, exception);
            }
        }
        return ValueTask.FromResult<IReadOnlyList<EveClientInfo>>(clients);
    }
}
