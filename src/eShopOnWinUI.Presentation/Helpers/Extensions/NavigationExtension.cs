using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Helpers.Extensions;

// Extension class to set the navigation target for a NavigationViewItem.
//
// Usage in XAML:
// <NavigationViewItem x:Uid="Shell_Main" Icon="Document" extensions:NavigationExtension.NavigateTo="AppName.ViewModels.MainViewModel" />
//
// Usage in code:
// NavigationExtension.SetNavigateTo(navigationViewItem, typeof(MainViewModel).FullName);
public sealed class NavigationExtension
{
    public static readonly DependencyProperty NavigateToProperty =
        DependencyProperty.RegisterAttached("NavigateTo", typeof(string), typeof(NavigationExtension), new PropertyMetadata(null));

    public static string GetNavigateTo(NavigationViewItem item)
    {
        return (string)item.GetValue(NavigateToProperty);
    }

    public static void SetNavigateTo(NavigationViewItem item, string value)
    {
        item.SetValue(NavigateToProperty, value);
    }
}