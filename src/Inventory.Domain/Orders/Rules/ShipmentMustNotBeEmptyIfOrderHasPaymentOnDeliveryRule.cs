using Inventory.Domain.SeedWork.BusinessRules;
using Inventory.Domain.Shipments;

namespace Inventory.Domain.Orders.Rules;

internal sealed record ShipmentMustNotBeEmptyIfOrderHasPaymentOnDeliveryRule(PaymentType PaymentType, Shipment? Shipment) : IBusinessRule
{
    public string Message => "Shipment information must not be empty if order suppose to be paid on delivery time.";

    public bool BrokenWhen
        => PaymentType is PaymentType.OnDelivery
        && Shipment is null;
}
