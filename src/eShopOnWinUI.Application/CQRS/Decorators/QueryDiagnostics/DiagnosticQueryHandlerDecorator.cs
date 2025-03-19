using System.Diagnostics;
using eShopOnWinUI.Application.CQRS.Queries;

namespace eShopOnWinUI.Application.CQRS.Decorators.QueryDiagnostics;

public sealed class DiagnosticQueryHandlerDecorator<TQuery, TResult>(IQueryHandler<TQuery, TResult> decorated) : IQueryHandler<TQuery, TResult>
   where TQuery : IQuery<TResult>
{
    public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();

        var result = await decorated.Handle(query, cancellationToken);

        stopwatch.Stop();

        // TODO: Display the query execution speed.
        return result;
    }
}