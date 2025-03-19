using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Shipments.Rules;

internal sealed record ShipmentCityMustNotBeEmpty(string City) : IBusinessRule
{
    public string Message => "Shipment city must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(City);
}