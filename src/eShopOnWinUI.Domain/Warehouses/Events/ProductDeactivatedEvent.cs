using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.Products;
using MediatR;

namespace eShopOnWinUI.Domain.Warehouses.Events;

public sealed record ProductDeactivatedEvent(ProductId ProductId, int RemainingProductsQuantity, DocumentId DocumentId)
    : WarehouseEventBase(ProductId, RemainingProductsQuantity, DocumentId), INotification;