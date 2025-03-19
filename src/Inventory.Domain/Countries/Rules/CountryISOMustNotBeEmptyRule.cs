using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Countries.Rules;

internal sealed record CountryISOMustNotBeEmptyRule(string ISO) : IBusinessRule
{
    public string Message => "Country ISO must not be empty!";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(ISO);
}