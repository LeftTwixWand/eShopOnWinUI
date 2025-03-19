namespace eShopOnWinUI.Domain.SeedWork.Events;

/// <summary>
/// Domain event abstraction, that stores information, when the event was occurred on.
/// </summary>
public abstract record DomainEventBase : IDomainEvent
{
    /// <inheritdoc/>
    public DateTimeOffset OccurredOn => DateTimeOffset.Now;

    // TODO: Add unique guid identifier for the future idempotence retrying mechanism.
}