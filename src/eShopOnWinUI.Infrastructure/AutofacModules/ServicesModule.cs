using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using eShopOnWinUI.Application.Services.Activation;
using eShopOnWinUI.Application.Services.Activation.Handlers;
using eShopOnWinUI.Application.Services.ThemeSelector;
using eShopOnWinUI.Domain.SeedWork.Events;
using eShopOnWinUI.Domain.SeedWork.UnitOfWorks;
using eShopOnWinUI.Infrastructure.Services.Activation;
using eShopOnWinUI.Infrastructure.Services.ThemeSelector;
using eShopOnWinUI.Infrastructure.Services.UnitOfWorks;
using eShopOnWinUI.Infrastructure.Services.UnitOfWorks.DomainEventsDispatching;
using Microsoft.UI.Xaml;

namespace eShopOnWinUI.Infrastructure.AutofacModules;

internal sealed class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ActivationService>().As<IActivationService>().InstancePerLifetimeScope();

        builder.RegisterType<DefaultActivationHandler>().As<ActivationHandler<LaunchActivatedEventArgs>>().InstancePerDependency();

        builder.RegisterType<DomainEventsDispatcher>().As<IDomainEventsDispatcher>().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().SingleInstance();
        builder.RegisterInstance<IMessenger>(WeakReferenceMessenger.Default).SingleInstance();
    }
}