namespace eShopOnWinUI.Domain.Shipments;

public readonly record struct ShipmentId(Guid Value)
{
    public static ShipmentId New => new(Guid.NewGuid());
}