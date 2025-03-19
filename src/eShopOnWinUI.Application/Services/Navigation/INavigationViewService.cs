using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Application.Services.Navigation;

public interface INavigationViewService
{
    IList<object> MenuItems { get; }

    object SettingsItem { get; }

    Type SettingsViewType { get; }

    void Initialize(NavigationView navigationView);

    void UnregisterEvents();

    NavigationViewItem? GetSelectedItem(Type pageType);
}