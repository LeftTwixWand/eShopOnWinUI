using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.OrderItems.Rules;

internal sealed record DiscountCanNotBeMoreThanHundredPercent(decimal Discount) : IBusinessRule
{
    public string Message => "Discount can not be more than hundred percent.";

    public bool BrokenWhen => Discount > 100;
}