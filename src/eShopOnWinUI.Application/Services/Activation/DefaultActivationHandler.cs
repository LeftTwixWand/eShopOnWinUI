using eShopOnWinUI.Application.Services.Activation.Handlers;
using eShopOnWinUI.Application.Services.Navigation;
using eShopOnWinUI.Application.ViewModels.Dashboard;
using Microsoft.UI.Xaml;

namespace eShopOnWinUI.Application.Services.Activation;

public sealed class DefaultActivationHandler(INavigationService navigationService) : ActivationHandler<LaunchActivatedEventArgs>
{
    protected override bool CanHandleInternal(LaunchActivatedEventArgs? args)
    {
        // None of the ActivationHandlers has handled the activation.
        return navigationService.Frame?.Content == null;
    }

    protected override async Task HandleInternalAsync(LaunchActivatedEventArgs? args)
    {
        navigationService.Navigate<DashboardViewModel>();

        await Task.CompletedTask;
    }
}