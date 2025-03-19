using CommunityToolkit.Mvvm.DependencyInjection;
using eShopOnWinUI.Application.ViewModels.ActivityLog;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Views.ActivityLog;

public sealed partial class ActivityLogView : Page
{
    public ActivityLogView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<ActivityLogViewModel>();
    }

    private ActivityLogViewModel ViewModel { get; }
}