using CommunityToolkit.Mvvm.DependencyInjection;
using eShopOnWinUI.Application.ViewModels.Customers;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Views.Customers;

public sealed partial class CustomersView : Page
{
    public CustomersView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<CustomersViewModel>();
    }

    private CustomersViewModel ViewModel { get; }
}