using eShopOnWinUI.Application.Services.Activation;
using eShopOnWinUI.Application.Services.Activation.Handlers;
using eShopOnWinUI.Application.Services.ThemeSelector;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Infrastructure.Services.Activation;

public class ActivationService(ActivationHandler<LaunchActivatedEventArgs> defaultHandler, IEnumerable<IActivationHandler> activationHandlers, IThemeSelectorService themeSelectorService, Window window) : IActivationService
{
    public async Task ActivateAsync(UIElement shellView, object activationArgs)
    {
        // Execute tasks before activation.
        await InitializeAsync();

        // Set the MainWindow Content.
        if (window.Content == null)
        {
            window.Content = shellView ?? new Frame();
        }

        // Handle activation via ActivationHandlers.
        await HandleActivationAsync(activationArgs);

        // Activate the MainWindow.
        window.Activate();

        // Execute tasks after activation.
        await StartupAsync();
    }

    private async Task HandleActivationAsync(object activationArgs)
    {
        var activationHandler = activationHandlers.FirstOrDefault(handler => handler.CanHandle(activationArgs));

        if (activationHandler is not null)
        {
            await activationHandler.HandleAsync(activationArgs);
        }

        if (defaultHandler.CanHandle(activationArgs))
        {
            await defaultHandler.HandleAsync(activationArgs);
        }
    }

    private async Task InitializeAsync()
    {
        themeSelectorService.Initialize();
        await Task.CompletedTask;
    }

    private async Task StartupAsync()
    {
        themeSelectorService.SetRequestedTheme();
        await Task.CompletedTask;
    }
}