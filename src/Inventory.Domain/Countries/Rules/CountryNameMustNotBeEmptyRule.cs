using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Countries.Rules;

internal sealed record CountryNameMustNotBeEmptyRule(string Name) : IBusinessRule
{
    public string Message => "Country name must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Name);
}