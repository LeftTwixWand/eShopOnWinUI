using eShopOnWinUI.Application.CQRS.Commands;
using eShopOnWinUI.Domain.SeedWork.UnitOfWorks;
using MediatR;

namespace eShopOnWinUI.Application.CQRS.Decorators.UnitOfWork;

public sealed class UnitOfWorkCommandHandlerDecorator<TCommand>(IRequestHandler<TCommand> decorated, IUnitOfWork unitOfWork) : ICommandHandler<TCommand>
        where TCommand : ICommand
{
    public async Task Handle(TCommand command, CancellationToken cancellationToken)
    {
        await decorated.Handle(command, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}

public sealed class UnitOfWorkCommandHandlerDecorator<TCommand, TResult>(IRequestHandler<TCommand, TResult> decorated, IUnitOfWork unitOfWork) : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
{
    public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
    {
        var result = await decorated.Handle(command, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}