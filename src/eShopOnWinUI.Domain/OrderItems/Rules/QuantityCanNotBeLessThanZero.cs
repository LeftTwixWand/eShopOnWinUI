using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.OrderItems.Rules;

internal sealed record QuantityCanNotBeLessThanZero(decimal Quantity) : IBusinessRule
{
    public string Message => "Quantity can not be less than zero.";

    public bool BrokenWhen => Quantity < 0;
}