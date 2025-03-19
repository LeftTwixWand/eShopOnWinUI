using Autofac;
using eShopOnWinUI.Application.CQRS.Decorators.Logging;
using eShopOnWinUI.Application.CQRS.Decorators.QueryDiagnostics;
using eShopOnWinUI.Application.CQRS.Decorators.UnitOfWork;
using eShopOnWinUI.Application.CQRS.RequestProcessors.Validation;
using eShopOnWinUI.Infrastructure.AutofacModules.Helpers;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Pipeline;

namespace eShopOnWinUI.Infrastructure.AutofacModules;

internal sealed class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var configuration = MediatRConfigurationBuilder
           .Create(ExternalAssemblies.ApplicationLayer)
           .WithAllOpenGenericHandlerTypesRegistered()
           .Build();

        builder.RegisterMediatR(configuration);

        builder.RegisterGeneric(typeof(ValidationRequestPreProcessor<>)).As(typeof(IRequestPreProcessor<>));

        builder.RegisterGenericDecorator(typeof(UnitOfWorkCommandHandlerDecorator<>), typeof(IRequestHandler<>));
        builder.RegisterGenericDecorator(typeof(LoggingRequestHandlerDecorator<>), typeof(IRequestHandler<>));

        builder.RegisterGenericDecorator(typeof(UnitOfWorkCommandHandlerDecorator<,>), typeof(IRequestHandler<,>));
        builder.RegisterGenericDecorator(typeof(LoggingRequestHandlerDecorator<,>), typeof(IRequestHandler<,>));
        builder.RegisterGenericDecorator(typeof(DiagnosticQueryHandlerDecorator<,>), typeof(IRequestHandler<,>));
    }
}