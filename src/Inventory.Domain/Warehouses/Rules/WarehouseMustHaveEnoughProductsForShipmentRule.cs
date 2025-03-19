using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Warehouses.Rules;

internal sealed record WarehouseMustHaveEnoughProductsForShipmentRule(int QuantityForShipment, int ActualProductsQuantity) : IBusinessRule
{
    public string Message => $"There are not enough products in warehouse to perform shipment.";

    public bool BrokenWhen => ActualProductsQuantity < QuantityForShipment;
}