using eShopOnWinUI.Application.CQRS.Requests;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eShopOnWinUI.Application.CQRS.Decorators.Logging;

public sealed class LoggingRequestHandlerDecorator<TRequest>(ILogger logger, IRequestHandler<TRequest> decorated) : IRequestHandler<TRequest>
    where TRequest : IIdentifiableRequest
{
    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Executing request {Request}", request);
            await decorated.Handle(request, cancellationToken);
            logger.LogInformation("Request executed successfully");
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Request processing failed");
            throw new Exception("Exception happens while operation execution.", exception);
        }
    }
}

public sealed class LoggingRequestHandlerDecorator<TRequest, TResult>(ILogger logger, IRequestHandler<TRequest, TResult> decorated) : IRequestHandler<TRequest, TResult>
    where TRequest : IIdentifiableRequest<TResult>
{
    public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Executing request {Request}", request);
            var result = await decorated.Handle(request, cancellationToken);
            logger.LogInformation("Request executed successfully, result {Result}", result);
            return result;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Request processing failed");
            throw new Exception("Exception happens while operation execution.", exception);
        }
    }
}