using MediatR;

namespace eShopOnWinUI.Application.CQRS.Queries;

/// <summary>
/// Base interface, for all query handlers.
/// </summary>
/// <typeparam name="TQuery">Type of the query, that will be handled.</typeparam>
/// <typeparam name="TResult">Type of the object, that will be returned as query execution result.</typeparam>
public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
       where TQuery : IQuery<TResult>
{
}