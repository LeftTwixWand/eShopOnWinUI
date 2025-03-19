using CommunityToolkit.Mvvm.ComponentModel;

namespace eShopOnWinUI.Application.ViewModels.Dashboard;

public sealed partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "myText";
}