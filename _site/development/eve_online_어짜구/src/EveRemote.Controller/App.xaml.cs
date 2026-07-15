using System.Windows;
using EveRemote.Controller.Services;
using EveRemote.Controller.ViewModels;
using Microsoft.Extensions.Configuration;
namespace EveRemote.Controller;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: false).Build();
        var monitor = new AgentMonitorService(configuration);
        new MainWindow(new MainViewModel(monitor)).Show();
    }
}
