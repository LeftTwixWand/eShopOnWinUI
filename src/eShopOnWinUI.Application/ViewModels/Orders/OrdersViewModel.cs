using CommunityToolkit.Mvvm.ComponentModel;

namespace eShopOnWinUI.Application.ViewModels.Orders;

public sealed partial class OrdersViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "Some text";
}