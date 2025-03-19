using eShopOnWinUI.Domain.Warehouses.Events;
using MediatR;

namespace eShopOnWinUI.Application.Features.Product;

internal sealed class ProductDeactivatedNotificationHandler : INotificationHandler<ProductDeactivatedEvent>
{
    public Task Handle(ProductDeactivatedEvent @event, CancellationToken cancellationToken)
    {
        if (@event.RemainingProductsQuantity > 0)
        {
            // Handle remaining products management in warehouse.
        }

        return Task.CompletedTask;
    }
}