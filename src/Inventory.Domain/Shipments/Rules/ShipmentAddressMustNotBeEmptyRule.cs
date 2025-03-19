using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Shipments.Rules;

internal sealed record ShipmentAddressMustNotBeEmptyRule(string Address) : IBusinessRule
{
    public string Message => "Shipment address must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Address);
}