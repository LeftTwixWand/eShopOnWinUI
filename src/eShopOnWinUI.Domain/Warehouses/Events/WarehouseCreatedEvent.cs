using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.Products;

namespace eShopOnWinUI.Domain.Warehouses.Events;

public sealed record WarehouseCreatedEvent(ProductId ProductId) : WarehouseEventBase(ProductId, 0, new DocumentId(Guid.Empty));