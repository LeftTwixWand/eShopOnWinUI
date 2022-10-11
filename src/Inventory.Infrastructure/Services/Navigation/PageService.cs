﻿using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.ActivityLog;
using Inventory.Application.ViewModels.ContentGrid;
using Inventory.Application.ViewModels.Customers;
using Inventory.Application.ViewModels.Dashboard;
using Inventory.Application.ViewModels.DataGrid;
using Inventory.Application.ViewModels.ListDetails;
using Inventory.Application.ViewModels.Main;
using Inventory.Application.ViewModels.Orders;
using Inventory.Application.ViewModels.Products;
using Inventory.Application.ViewModels.Settings;
using Inventory.Application.ViewModels.WebView;
using Inventory.Presentation.Views;
using Inventory.Presentation.Views.ActivityLog;
using Inventory.Presentation.Views.Customers;
using Inventory.Presentation.Views.Dashboard;
using Inventory.Presentation.Views.Orders;
using Inventory.Presentation.Views.Products;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Infrastructure.Services.Navigation;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<MainViewModel, MainPage>();
        Configure<WebViewViewModel, WebViewPage>();
        Configure<ListDetailsViewModel, ListDetailsPage>();
        Configure<ContentGridViewModel, ContentGridPage>();
        Configure<ContentGridDetailViewModel, ContentGridDetailPage>();
        Configure<DataGridViewModel, DataGridPage>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<DashboardViewModel, DashboardView>();
        Configure<CustomersViewModel, CustomersView>();
        Configure<ProductsViewModel, ProductsView>();
        Configure<OrdersViewModel, OrdersView>();
        Configure<ActivityLogViewModel, ActivityLogView>();
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
