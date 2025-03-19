using Inventory.Application.CQRS.Requests;

namespace Inventory.Application.CQRS.Commands;

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="ICommand"/> and adding request identity.
/// </summary>
public abstract record CommandBase : RequestBase, ICommand;

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="ICommand{TResult}"/> and adding request identity.
/// </summary>
/// <typeparam name="TResult"><inheritdoc cref="RequestBase{TResult}" path="/typeparam"/></typeparam>
public abstract record CommandBase<TResult> : RequestBase<TResult>, ICommand<TResult>;