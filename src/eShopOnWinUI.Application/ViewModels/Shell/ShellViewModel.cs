using CommunityToolkit.Mvvm.ComponentModel;
using eShopOnWinUI.Application.Services.Navigation;
using Microsoft.UI.Xaml.Navigation;

namespace eShopOnWinUI.Application.ViewModels.Shell;

public sealed partial class ShellViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBackEnabled;

    [ObservableProperty]
    private object? _selected;

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationViewService = navigationViewService;
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
    }

    public INavigationService NavigationService { get; }

    public INavigationViewService NavigationViewService { get; }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == NavigationViewService.SettingsViewType)
        {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem is not null)
        {
            Selected = selectedItem;
        }
    }
}