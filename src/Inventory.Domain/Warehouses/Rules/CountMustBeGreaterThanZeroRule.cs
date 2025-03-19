using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.Warehouses.Rules;

internal sealed record CountMustBeGreaterThanZeroRule(int Count) : IBusinessRule
{
    public string Message => "Count must be greater than zero.";

    public bool BrokenWhen => Count <= 0;
}