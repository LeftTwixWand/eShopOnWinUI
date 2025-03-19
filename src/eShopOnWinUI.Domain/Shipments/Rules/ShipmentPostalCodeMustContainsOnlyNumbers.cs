using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Shipments.Rules;

internal sealed record ShipmentPostalCodeMustContainsOnlyNumbers(string PostalCode) : IBusinessRule
{
    public string Message => "Shipment postal code must contains only numbers!";

    public bool BrokenWhen => PostalCode.All(char.IsNumber) is false;
}