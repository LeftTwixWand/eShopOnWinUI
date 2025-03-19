using Inventory.Domain.Documents;
using Inventory.Domain.Products;
using Inventory.Domain.SeedWork.AggregateRoots;
using Inventory.Domain.SeedWork.Entities;
using Inventory.Domain.Warehouses.Events;
using Inventory.Domain.Warehouses.Projections;
using Inventory.Domain.Warehouses.Rules;

namespace Inventory.Domain.Warehouses;

public sealed class Warehouse : Entity<WarehouseEventBase>, IAggregateRoot
{
    private Warehouse(ProductId productId)
    {
        ProductId = productId;
    }

    public ProductId ProductId { get; init; }

    public static Warehouse Create(ProductId productId)
    {
        var warehouse = new Warehouse(productId);

        warehouse.AddDomainEvent(new WarehouseCreatedEvent(productId));

        return warehouse;
    }

    public void ShipProducts(int count, ActualProductQuantityProjection actualProductQuantityProjection, DocumentId documentId)
    {
        var actualProductQuantity = actualProductQuantityProjection.GetActualProductQuantity();

        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new WarehouseMustHaveEnoughProductsForShipmentRule(QuantityForShipment: count, actualProductQuantity)); // TODO: Move it to the Order stage
        CheckRule(new AttachedDocumentIdMustNotBeEmptyRule(documentId));

        AddDomainEvent(new ProductsShippedEvent(ProductId, count, documentId));
    }

    public void ReceiveProducts(int count, DocumentId documentId)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new AttachedDocumentIdMustNotBeEmptyRule(documentId));

        AddDomainEvent(new ProductsReceivedEvent(ProductId, count, documentId));
    }

    public void DeclareMissedProducts(int count, DocumentId documentId)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new AttachedDocumentIdMustNotBeEmptyRule(documentId));

        AddDomainEvent(new ProductsMissedEvent(ProductId, count, documentId));
    }

    public void DeactivateProduct(ActualProductQuantityProjection actualProductQuantityProjection, DocumentId documentId)
    {
        CheckRule(new AttachedDocumentIdMustNotBeEmptyRule(documentId));

        var actualProductQuantity = actualProductQuantityProjection.GetActualProductQuantity();

        AddDomainEvent(new ProductDeactivatedEvent(ProductId, actualProductQuantity, documentId));
    }
}