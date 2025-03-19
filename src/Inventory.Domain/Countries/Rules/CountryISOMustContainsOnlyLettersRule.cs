using CommunityToolkit.Common;
using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Countries.Rules;

internal sealed record CountryISOMustContainsOnlyLettersRule(string ISO) : IBusinessRule
{
    public string Message => "Country ISO must contains only letters.";

    public bool BrokenWhen => ISO.IsCharacterString() is false;
}