using CommunityToolkit.Mvvm.ComponentModel;
using eShopOnWinUI.Application.Services.Navigation;
using eShopOnWinUI.Application.ViewModels.ActivityLog;
using eShopOnWinUI.Application.ViewModels.Customers;
using eShopOnWinUI.Application.ViewModels.Dashboard;
using eShopOnWinUI.Application.ViewModels.Orders;
using eShopOnWinUI.Application.ViewModels.Product;
using eShopOnWinUI.Application.ViewModels.Products;
using eShopOnWinUI.Application.ViewModels.Settings;
using eShopOnWinUI.Presentation.Views.ActivityLog;
using eShopOnWinUI.Presentation.Views.Customers;
using eShopOnWinUI.Presentation.Views.Dashboard;
using eShopOnWinUI.Presentation.Views.Orders;
using eShopOnWinUI.Presentation.Views.Product;
using eShopOnWinUI.Presentation.Views.Products;
using eShopOnWinUI.Presentation.Views.Settings;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Infrastructure.Services.Navigation;

internal sealed class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = [];

    public PageService()
    {
        Configure<SettingsViewModel, SettingsPage>();
        Configure<DashboardViewModel, DashboardView>();
        Configure<CustomersViewModel, CustomersView>();
        Configure<ProductsViewModel, ProductsView>();
        Configure<OrdersViewModel, OrdersView>();
        Configure<ActivityLogViewModel, ActivityLogView>();
        Configure<ProductViewModel, ProductView>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<TViewModel, TView>()
        where TViewModel : ObservableObject
        where TView : Page
    {
        lock (_pages)
        {
            var key = typeof(TViewModel).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(TView);
            if (_pages.Any(p => p.Value == type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
