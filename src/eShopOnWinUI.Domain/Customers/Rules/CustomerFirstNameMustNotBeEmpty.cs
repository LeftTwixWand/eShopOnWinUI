using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Customers.Rules;

internal sealed record CustomerFirstNameMustNotBeEmpty(string FirstName) : IBusinessRule
{
    public string Message => "Customer first name must not be empty.";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(FirstName);
}