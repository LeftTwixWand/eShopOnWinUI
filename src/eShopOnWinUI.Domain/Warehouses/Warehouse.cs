using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.SeedWork.AggregateRoots;
using eShopOnWinUI.Domain.SeedWork.Entities;
using eShopOnWinUI.Domain.Warehouses.Events;
using eShopOnWinUI.Domain.Warehouses.Projections;
using eShopOnWinUI.Domain.Warehouses.Rules;

namespace eShopOnWinUI.Domain.Warehouses;

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

        CheckRule(new CountMustBeGreaterThanZero(count));
        CheckRule(new WarehouseMustHaveEnoughProductsForShipment(QuantityForShipment: count, actualProductQuantity)); // TODO: Move it to the Order stage
        CheckRule(new AttachedDocumentIdMustNotBeEmpty(documentId));

        AddDomainEvent(new ProductsShippedEvent(ProductId, count, documentId));
    }

    public void ReceiveProducts(int count, DocumentId documentId)
    {
        CheckRule(new CountMustBeGreaterThanZero(count));
        CheckRule(new AttachedDocumentIdMustNotBeEmpty(documentId));

        AddDomainEvent(new ProductsReceivedEvent(ProductId, count, documentId));
    }

    public void DeclareMissedProducts(int count, DocumentId documentId)
    {
        CheckRule(new CountMustBeGreaterThanZero(count));
        CheckRule(new AttachedDocumentIdMustNotBeEmpty(documentId));

        AddDomainEvent(new ProductsMissedEvent(ProductId, count, documentId));
    }

    public void DeactivateProduct(ActualProductQuantityProjection actualProductQuantityProjection, DocumentId documentId)
    {
        CheckRule(new AttachedDocumentIdMustNotBeEmpty(documentId));

        var actualProductQuantity = actualProductQuantityProjection.GetActualProductQuantity();

        AddDomainEvent(new ProductDeactivatedEvent(ProductId, actualProductQuantity, documentId));
    }
}