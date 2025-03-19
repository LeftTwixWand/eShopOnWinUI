using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Shipments.Rules;

internal sealed record ShipmentCityMustNotBeEmptyRule(string City) : IBusinessRule
{
    public string Message => "Shipment city must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(City);
}