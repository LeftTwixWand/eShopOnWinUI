using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Warehouses.Rules;

internal sealed record CountMustBeGreaterThanZero(int Count) : IBusinessRule
{
    public string Message => "Count must be greater than zero.";

    public bool BrokenWhen => Count <= 0;
}