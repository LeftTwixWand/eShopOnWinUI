using Inventory.Domain.Documents;
using Inventory.Domain.Products;
using Inventory.Domain.SeedWork.Events;

namespace Inventory.Domain.Warehouses.Events;

public abstract record WarehouseEventBase(ProductId ProductId, int Count, DocumentId DocumentId) : DomainEventBase;