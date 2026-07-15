using System.Collections.ObjectModel;
using EveRemote.Controller.Services;
namespace EveRemote.Controller.ViewModels;

public sealed class MainViewModel : BindableBase, IDisposable
{
    private readonly AgentMonitorService _monitor;
    private readonly CancellationTokenSource _shutdown = new();
    private AgentViewModel? _selectedAgent;
    public MainViewModel(AgentMonitorService monitor)
    {
        _monitor = monitor;
        Agents = new(monitor.Endpoints.Select(static item => new AgentViewModel(item)));
        SelectedAgent = Agents.FirstOrDefault();
    }
    public ObservableCollection<AgentViewModel> Agents { get; }
    public AgentViewModel? SelectedAgent { get => _selectedAgent; set => SetProperty(ref _selectedAgent, value); }
    public void Start() => _ = PollLoopAsync(_shutdown.Token);
    private async Task PollLoopAsync(CancellationToken cancellationToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(2));
        do
        {
            foreach (AgentViewModel agent in Agents)
            {
                try { agent.Apply(await _monitor.PollAsync(agent.Configuration, cancellationToken)); }
                catch (Exception exception) when (exception is not OperationCanceledException) { agent.MarkDisconnected(); }
            }
        }
        while (await timer.WaitForNextTickAsync(cancellationToken));
    }
    public void Dispose() { _shutdown.Cancel(); _shutdown.Dispose(); _monitor.Dispose(); }
}
