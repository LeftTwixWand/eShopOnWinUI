using System.Threading.Tasks;
using Inventory.Application.Services.Activation.Handlers;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.Dashboard;
using Microsoft.UI.Xaml;

namespace Inventory.Application.Services.Activation;

public sealed class DefaultActivationHandler(INavigationService navigationService) : ActivationHandler<LaunchActivatedEventArgs>
{
    protected override bool CanHandleInternal(LaunchActivatedEventArgs? args)
    {
        // None of the ActivationHandlers has handled the activation.
        return navigationService.Frame?.Content == null;
    }

    protected override async Task HandleInternalAsync(LaunchActivatedEventArgs? args)
    {
        navigationService.NavigateTo(typeof(DashboardViewModel).FullName!, args?.Arguments);

        await Task.CompletedTask;
    }
}