using eShopOnWinUI.Application.Services.Navigation;
using eShopOnWinUI.Application.ViewModels.Settings;
using eShopOnWinUI.Presentation.Helpers.Extensions;
using eShopOnWinUI.Presentation.Views.Settings;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Infrastructure.Services.Navigation;

public sealed class NavigationViewService(INavigationService navigationService, IPageService pageService) : INavigationViewService
{
    private NavigationView _navigationView = default!;

    public IList<object> MenuItems => _navigationView.MenuItems;

    public object SettingsItem => _navigationView.SettingsItem;

    public Type SettingsViewType => typeof(SettingsPage);

    public void Initialize(NavigationView navigationView)
    {
        _navigationView = navigationView;
        _navigationView.BackRequested += OnBackRequested;
        _navigationView.ItemInvoked += OnItemInvoked;
    }

    public void UnregisterEvents()
    {
        _navigationView.BackRequested -= OnBackRequested;
        _navigationView.ItemInvoked -= OnItemInvoked;
    }

    public NavigationViewItem? GetSelectedItem(Type pageType)
    {
        return GetSelectedItem(_navigationView.MenuItems, pageType) ?? GetSelectedItem(_navigationView.FooterMenuItems, pageType);
    }

    private void OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
    {
        navigationService.GoBack();
    }

    private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            navigationService.NavigateTo(typeof(SettingsViewModel).FullName!);
        }
        else
        {
            var selectedItem = args.InvokedItemContainer as NavigationViewItem;

            if (selectedItem?.GetValue(NavigationExtension.NavigateToProperty) is string pageKey)
            {
                navigationService.NavigateTo(pageKey);
            }
        }
    }

    private NavigationViewItem? GetSelectedItem(IEnumerable<object> menuItems, Type pageType)
    {
        foreach (var item in menuItems.OfType<NavigationViewItem>())
        {
            if (IsMenuItemForPageType(item, pageType))
            {
                return item;
            }

            var selectedChild = GetSelectedItem(item.MenuItems, pageType);
            if (selectedChild != null)
            {
                return selectedChild;
            }
        }

        return null;
    }

    private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
    {
        return menuItem.GetValue(NavigationExtension.NavigateToProperty) is string pageKey
            && pageService.GetPageType(pageKey) == sourcePageType;
    }
}