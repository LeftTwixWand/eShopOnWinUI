using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.SeedWork.Events;

namespace eShopOnWinUI.Domain.Warehouses.Events;

public abstract record WarehouseEventBase(ProductId ProductId, int Count, DocumentId DocumentId) : DomainEventBase;