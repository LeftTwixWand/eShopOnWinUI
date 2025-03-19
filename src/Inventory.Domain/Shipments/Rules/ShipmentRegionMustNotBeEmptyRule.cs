using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Shipments.Rules;

internal sealed record ShipmentRegionMustNotBeEmptyRule(string Region) : IBusinessRule
{
    public string Message => "Shipment region must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Message);
}