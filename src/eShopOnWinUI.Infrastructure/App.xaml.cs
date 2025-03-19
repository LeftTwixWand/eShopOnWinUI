using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using eShopOnWinUI.Application.Services.Activation;
using eShopOnWinUI.Infrastructure.AutofacModules;
using eShopOnWinUI.Presentation.Views.Shell;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace eShopOnWinUI.Infrastructure;

public sealed partial class App : Microsoft.UI.Xaml.Application
{
    private readonly IHost _host;

    public App()
    {
        InitializeComponent();

        _host = new HostBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
            {
                containerBuilder
                    .RegisterModule<NavigationModule>()
                    .RegisterModule<ServicesModule>()
                    .RegisterModule<MediatorModule>();
            }))
            .Build();

        UnhandledException += App_UnhandledException;

        Ioc.Default.ConfigureServices(_host.Services);
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        ShellView shellView = Ioc.Default.GetRequiredService<ShellView>();
        IActivationService activationService = Ioc.Default.GetRequiredService<IActivationService>();

        await activationService.ActivateAsync(shellView, args);
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}