using System.Collections.ObjectModel;
using System.Windows.Media;
using EveRemote.Controller.Services;
using EveRemote.Protocol.V1;
namespace EveRemote.Controller.ViewModels;

public sealed class AgentViewModel : BindableBase
{
    private string _machineName;
    private string _statusText = "연결 대기";
    private Brush _statusBrush = Brushes.Goldenrod;
    public AgentViewModel(AgentEndpoint endpoint)
    {
        Configuration = endpoint;
        _machineName = endpoint.Name;
    }
    public AgentEndpoint Configuration { get; }
    public string Endpoint => Configuration.Address;
    public ObservableCollection<EveClientViewModel> Clients { get; } = [];
    public string MachineName { get => _machineName; private set => SetProperty(ref _machineName, value); }
    public string StatusText { get => _statusText; private set => SetProperty(ref _statusText, value); }
    public Brush StatusBrush { get => _statusBrush; private set => SetProperty(ref _statusBrush, value); }
    public string ClientCountText => $"EVE 창 {Clients.Count}개";
    public void Apply(AgentPollResult result)
    {
        MachineName = result.Reply.MachineName;
        StatusText = $"연결됨 · {result.Latency.TotalMilliseconds:F0} ms";
        StatusBrush = Brushes.LimeGreen;
        Clients.Clear();
        foreach (EveClientStatus client in result.Reply.Clients) Clients.Add(new(client));
        Notify(nameof(ClientCountText));
    }
    public void MarkDisconnected()
    {
        StatusText = "연결 끊김"; StatusBrush = Brushes.IndianRed; Clients.Clear(); Notify(nameof(ClientCountText));
    }
}

public sealed record EveClientViewModel(string WindowTitle, int ProcessId, string Resolution, string State)
{
    public EveClientViewModel(EveClientStatus status) : this(
        string.IsNullOrWhiteSpace(status.WindowTitle) ? "(제목 없음)" : status.WindowTitle,
        status.ProcessId, $"{status.ClientWidth}×{status.ClientHeight}", status.IsMinimized ? "최소화" : "사용 가능") { }
}
