using eShopOnWinUI.Domain.SeedWork.BusinessRules;
using eShopOnWinUI.Domain.Shipments;

namespace eShopOnWinUI.Domain.Orders.Rules;

internal sealed record ShipmentMustNotBeEmptyIfOrderHasPaymentOnDelivery(PaymentType PaymentType, Shipment? Shipment) : IBusinessRule
{
    public string Message => "Shipment information must not be empty if order suppose to be paid on delivery time.";

    public bool BrokenWhen
        => PaymentType is PaymentType.OnDelivery
        && Shipment is null;
}
