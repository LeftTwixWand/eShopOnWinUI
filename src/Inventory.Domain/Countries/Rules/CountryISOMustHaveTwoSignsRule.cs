using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Countries.Rules;

internal sealed record CountryISOMustHaveTwoSignsRule(string ISO) : IBusinessRule
{
    public string Message => "Country ISO must have two signs!";

    public bool BrokenWhen => ISO.Length is not 2;
}