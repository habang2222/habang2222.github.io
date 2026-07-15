using System.ComponentModel;
using System.Diagnostics;
namespace EveRemote.Infrastructure.Windows;

public sealed class SystemProcessWindowSource : IProcessWindowSource
{
    public IEnumerable<ProcessWindowSnapshot> GetByProcessName(string processName)
    {
        foreach (Process process in Process.GetProcessesByName(processName))
        {
            using (process)
            {
                ProcessWindowSnapshot? snapshot = TryCreate(process, processName);
                if (snapshot is not null) yield return snapshot;
            }
        }
    }

    private static ProcessWindowSnapshot? TryCreate(Process process, string processName)
    {
        try { return new(processName, process.Id, process.MainWindowHandle, process.MainWindowTitle); }
        catch (Exception exception) when (exception is InvalidOperationException or Win32Exception) { return null; }
    }
}
