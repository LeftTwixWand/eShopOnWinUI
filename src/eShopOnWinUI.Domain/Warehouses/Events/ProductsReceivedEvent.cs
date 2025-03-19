using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.Products;

namespace eShopOnWinUI.Domain.Warehouses.Events;

public sealed record ProductsReceivedEvent(ProductId ProductId, int Count, DocumentId DocumentId) : WarehouseEventBase(ProductId, Count, DocumentId);