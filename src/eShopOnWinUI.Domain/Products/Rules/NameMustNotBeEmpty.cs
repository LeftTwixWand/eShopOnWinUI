using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Products.Rules;

internal sealed record NameMustNotBeEmpty(string Name) : IBusinessRule
{
    public string Message => "Product name must not be empty.";

    public bool BrokenWhen => string.IsNullOrEmpty(Name);
}