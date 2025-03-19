using CommunityToolkit.Mvvm.DependencyInjection;
using eShopOnWinUI.Application.ViewModels.Products;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Views.Products;

public sealed partial class ProductsView : Page
{
    public ProductsView()
    {
        InitializeComponent();
    }

    private ProductsViewModel ViewModel { get; } = Ioc.Default.GetRequiredService<ProductsViewModel>();
}