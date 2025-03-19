using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Shipments.Rules;

internal sealed record ShipmentAddressMustNotBeEmpty(string Address) : IBusinessRule
{
    public string Message => "Shipment address must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Address);
}