using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Shipments.Rules;

internal sealed record ShipmentRegionMustNotBeEmpty(string Region) : IBusinessRule
{
    public string Message => "Shipment region must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Message);
}