using CommunityToolkit.Mvvm.ComponentModel;

namespace eShopOnWinUI.Application.ViewModels.ActivityLog;

public sealed partial class ActivityLogViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "Some text";
}