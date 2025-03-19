using CommunityToolkit.Mvvm.ComponentModel;

namespace eShopOnWinUI.Application.ViewModels.Customers;

public sealed partial class CustomersViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "Some text";
}