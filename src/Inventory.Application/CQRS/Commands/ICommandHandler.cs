using MediatR;

namespace Inventory.Application.CQRS.Commands;

/// <summary>
/// Base interface, for all command handlers.
/// </summary>
/// <typeparam name="TCommand">Type of the command, that will be handled.</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

/// <summary>
/// <inheritdoc cref="ICommandHandler{TCommand}"/>
/// </summary>
/// <typeparam name="TCommand"><inheritdoc cref="ICommandHandler{TCommand}" path="/typeparam"/></typeparam>
/// <typeparam name="TResult">Type of the object, that will be returned as command execution result.</typeparam>
public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}