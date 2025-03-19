namespace eShopOnWinUI.Domain.SeedWork.Events;

public class UnknownEventException(IDomainEvent unknownEvent) : Exception($"No handler found for event {unknownEvent.GetType().FullName}")
{
    public IDomainEvent UnknownEvent { get; } = unknownEvent;

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"No handler found for event {UnknownEvent.GetType().FullName}";
    }
}