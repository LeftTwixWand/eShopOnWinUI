using CommunityToolkit.Mvvm.DependencyInjection;
using eShopOnWinUI.Application.ViewModels.Settings;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Views.Settings;

public sealed partial class SettingsPage : Page
{
    public SettingsPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<SettingsViewModel>();
        InitializeComponent();
    }

    public SettingsViewModel ViewModel { get; }
}