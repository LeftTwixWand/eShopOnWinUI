using eShopOnWinUI.Domain.SeedWork.BusinessRules;
namespace eShopOnWinUI.Domain.Shipments.Rules;

internal sealed record ShipmentPostalCodeMustNotBeEmpty(string PostalCode) : IBusinessRule
{
    public string Message => "Shipment postal code must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(PostalCode);
}