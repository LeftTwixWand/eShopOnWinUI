using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Shipments.Rules;

internal sealed record ShipmentPostalCodeMustNotBeEmptyRule(string PostalCode) : IBusinessRule
{
    public string Message => "Shipment postal code must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(PostalCode);
}