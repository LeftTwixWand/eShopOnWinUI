using Inventory.Domain.SeedWork.Events;
using Inventory.Domain.Warehouses.Events;
using Inventory.Domain.Warehouses.Snapshots;

namespace Inventory.Domain.Warehouses.Projections;

public sealed class ActualProductQuantityProjection(IReadOnlyCollection<WarehouseEventBase> domainEvents, Snapshot snapshot)
{
    private int quantity = snapshot.Quantity;

    public int GetActualProductQuantity()
    {
        foreach (var domainEvent in domainEvents)
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