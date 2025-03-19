namespace eShopOnWinUI.Domain.SeedWork.Events;

/// <summary>
/// Responsible for <see cref="BuildingBlocks.Domain.Entities.Entity.DomainEvents"/> forwarding from the Domain to the Application layer.
/// </summary>
public interface IDomainEventsDispatcher
{
    /// <summary>
    /// Forwards all the <see cref="BuildingBlocks.Domain.Entities.Entity.DomainEvents"/> to the application layer through the SQRS mechanism.
    /// </summary>
    /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous dispatching operation.</returns>
    Task DispatchEventsAsync(CancellationToken cancellationToken = default);
}