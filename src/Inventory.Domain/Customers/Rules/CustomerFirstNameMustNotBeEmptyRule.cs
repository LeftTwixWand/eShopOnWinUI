using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Customers.Rules;

internal sealed record CustomerFirstNameMustNotBeEmptyRule(string FirstName) : IBusinessRule
{
    public string Message => "Customer first name must not be empty.";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(FirstName);
}