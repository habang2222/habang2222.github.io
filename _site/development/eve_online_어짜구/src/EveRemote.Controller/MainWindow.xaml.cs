using System.Windows;
using EveRemote.Controller.ViewModels;
namespace EveRemote.Controller;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = viewModel;
        Loaded += OnLoaded;
        Closed += OnClosed;
    }
    private void OnLoaded(object sender, RoutedEventArgs e) => _viewModel.Start();
    private void OnClosed(object? sender, EventArgs e) => _viewModel.Dispose();
}
