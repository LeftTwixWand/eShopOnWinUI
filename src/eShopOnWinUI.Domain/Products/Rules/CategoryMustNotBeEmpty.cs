using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Products.Rules;

internal sealed record CategoryMustNotBeEmpty(string Category) : IBusinessRule
{
    public string Message => "Product category must not be empty.";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Category);
}