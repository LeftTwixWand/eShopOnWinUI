using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Products.Rules;

internal sealed record NameMustNotBeEmptyRule(string Name) : IBusinessRule
{
    public string Message => "Product name must not be empty.";

    public bool BrokenWhen => string.IsNullOrEmpty(Name);
}