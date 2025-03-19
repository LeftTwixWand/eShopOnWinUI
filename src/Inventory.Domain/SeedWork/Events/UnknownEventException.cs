namespace Inventory.Domain.SeedWork.Events;

public class UnknownEventException : Exception
{
    public UnknownEventException(IDomainEvent unknownEvent)
        : base($"No handler found for event {unknownEvent.GetType().FullName}")
    {
        UnknownEvent = unknownEvent;
    }

    public IDomainEvent UnknownEvent { get; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"No handler found for event {UnknownEvent.GetType().FullName}";
    }
}