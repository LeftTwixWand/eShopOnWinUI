using eShopOnWinUI.Application.ViewModels.Shell;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Views.Shell;

public sealed partial class ShellView : Page
{
    private readonly Window _window;

    public ShellView(ShellViewModel viewModel, Window mainWindow)
    {
        ViewModel = viewModel;
        _window = mainWindow;

        InitializeComponent();

        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.NavigationViewService.Initialize(NavigationViewControl);

        // A custom title bar is required for full window theme and Mica support.
        // https://docs.microsoft.com/windows/apps/develop/title-bar?tabs=winui3#full-customization
        mainWindow.SetTitleBar(AppTitleBar);
    }

    public ShellViewModel ViewModel { get; }

    private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
    {
        AppTitleBar.Margin = new Thickness()
        {
            Left = sender.CompactPaneLength * (sender.DisplayMode == NavigationViewDisplayMode.Minimal ? 2 : 1),
            Top = AppTitleBar.Margin.Top,
            Right = AppTitleBar.Margin.Right,
            Bottom = AppTitleBar.Margin.Bottom,
        };
    }
}