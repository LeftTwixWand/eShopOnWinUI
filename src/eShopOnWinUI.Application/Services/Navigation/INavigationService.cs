using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace eShopOnWinUI.Application.Services.Navigation;

public interface INavigationService
{
    event NavigatedEventHandler Navigated;

    bool CanGoBack { get; }

    Frame? Frame { get; set; }

    bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false);

    void Navigate<TViewModel>(object? parameter = null, bool clearNavigation = false)
        where TViewModel : ObservableObject;

    bool GoBack();

    void SetListDataItemForNextConnectedAnimation(object item);
}
