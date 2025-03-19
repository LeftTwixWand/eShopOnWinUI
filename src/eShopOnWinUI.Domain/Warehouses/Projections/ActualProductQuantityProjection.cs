using eShopOnWinUI.Domain.SeedWork.Events;
using eShopOnWinUI.Domain.Warehouses.Events;
using eShopOnWinUI.Domain.Warehouses.Snapshots;

namespace eShopOnWinUI.Domain.Warehouses.Projections;

public sealed class ActualProductQuantityProjection
{
    private readonly IReadOnlyCollection<WarehouseEventBase> _domainEvents;
    private int quantity;

    public ActualProductQuantityProjection(IReadOnlyCollection<WarehouseEventBase> domainEvents, Snapshot snapshot)
    {
        quantity = snapshot.Quantity;
        _domainEvents = domainEvents;
    }

    public int GetActualProductQuantity()
    {
        foreach (var domainEvent in _domainEvents)
        {
            quantity = domainEvent switch
            {
                WarehouseCreatedEvent @event => Apply(@event),
                ProductsShippedEvent @event => Apply(@event),
                ProductsReceivedEvent @event => Apply(@event),
                ProductsMissedEvent @event => Apply(@event),
                _ => throw new UnknownEventException(domainEvent)
            };
        }

        return quantity;
    }

    private static int Apply(WarehouseCreatedEvent _)
    {
        return 0;
    }

    private int Apply(ProductsReceivedEvent @event)
    {
        return quantity + @event.Count;
    }

    private int Apply(ProductsShippedEvent @event)
    {
        return quantity - @event.Count;
    }

    private int Apply(ProductsMissedEvent @event)
    {
        return quantity - @event.Count;
    }
}