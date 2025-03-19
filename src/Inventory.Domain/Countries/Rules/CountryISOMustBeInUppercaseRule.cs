using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Countries.Rules;

internal sealed record CountryISOMustBeInUppercaseRule(string ISO) : IBusinessRule
{
    public string Message => "Country ISO must be in uppercase!";

    public bool BrokenWhen => ISO.Any(char.IsLower);
}