namespace EveRemote.Infrastructure.Windows;
public interface IProcessWindowSource
{
    IEnumerable<ProcessWindowSnapshot> GetByProcessName(string processName);
}
