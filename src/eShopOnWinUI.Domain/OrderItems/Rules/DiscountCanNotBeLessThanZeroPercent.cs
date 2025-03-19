using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.OrderItems.Rules;

internal sealed record DiscountCanNotBeLessThanZeroPercent(decimal Discount) : IBusinessRule
{
    public string Message => "Discount can not be less than zero percent.";

    public bool BrokenWhen => Discount < 0;
}