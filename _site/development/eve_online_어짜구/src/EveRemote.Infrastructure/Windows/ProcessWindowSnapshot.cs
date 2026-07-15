namespace EveRemote.Infrastructure.Windows;
public sealed record ProcessWindowSnapshot(string ProcessName, int ProcessId, nint MainWindowHandle, string MainWindowTitle);
