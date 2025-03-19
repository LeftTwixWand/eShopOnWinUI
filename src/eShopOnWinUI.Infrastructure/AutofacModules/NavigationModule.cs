using Autofac;
using eShopOnWinUI.Application.Services.Navigation;
using eShopOnWinUI.Application.ViewModels.ActivityLog;
using eShopOnWinUI.Application.ViewModels.Customers;
using eShopOnWinUI.Application.ViewModels.Dashboard;
using eShopOnWinUI.Application.ViewModels.Orders;
using eShopOnWinUI.Application.ViewModels.Product;
using eShopOnWinUI.Application.ViewModels.Products;
using eShopOnWinUI.Application.ViewModels.Settings;
using eShopOnWinUI.Application.ViewModels.Shell;
using eShopOnWinUI.Infrastructure.Services.Navigation;
using eShopOnWinUI.Presentation.Views.Shell;
using eShopOnWinUI.Presentation.Windows;
using Microsoft.UI.Xaml;

namespace eShopOnWinUI.Infrastructure.AutofacModules;

internal sealed class NavigationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PageService>().As<IPageService>().SingleInstance();
        builder.RegisterType<NavigationViewService>().As<INavigationViewService>().SingleInstance();
        builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

        builder.RegisterType<MainWindow>().As<Window>().SingleInstance();
        builder.RegisterType<ShellView>().SingleInstance();

        builder.RegisterType<ShellViewModel>().InstancePerDependency();
        builder.RegisterType<DashboardViewModel>().InstancePerDependency();
        builder.RegisterType<CustomersViewModel>().InstancePerDependency();
        builder.RegisterType<OrdersViewModel>().InstancePerDependency();
        builder.RegisterType<ActivityLogViewModel>().InstancePerDependency();
        builder.RegisterType<SettingsViewModel>().InstancePerDependency();
        builder.RegisterType<ProductsViewModel>().SingleInstance();
        builder.RegisterType<ProductViewModel>().InstancePerDependency();
    }
}