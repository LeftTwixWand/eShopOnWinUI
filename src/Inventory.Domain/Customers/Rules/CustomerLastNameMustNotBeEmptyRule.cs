using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Customers.Rules;

internal sealed record CustomerLastNameMustNotBeEmptyRule(string LastName) : IBusinessRule
{
    public string Message => "Customer last name must not be empty.";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(LastName);
}