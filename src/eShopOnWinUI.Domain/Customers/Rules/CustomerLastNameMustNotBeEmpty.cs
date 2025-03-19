using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Customers.Rules;

internal sealed record CustomerLastNameMustNotBeEmpty(string LastName) : IBusinessRule
{
    public string Message => "Customer last name must not be empty.";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(LastName);
}