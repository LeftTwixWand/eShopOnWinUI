using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Warehouses.Rules;

internal sealed record WarehouseMustHaveEnoughProductsForShipment(int QuantityForShipment, int ActualProductsQuantity) : IBusinessRule
{
    public string Message => $"There are not enough products in warehouse to perform shipment.";

    public bool BrokenWhen => ActualProductsQuantity < QuantityForShipment;
}