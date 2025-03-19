using eShopOnWinUI.Domain.SeedWork.BusinessRules;
namespace eShopOnWinUI.Domain.OrderItems.Rules;

internal sealed record PriceCanNotBeLessThanZero(decimal Price) : IBusinessRule
{
    public string Message => "Price can not be less than zero.";

    public bool BrokenWhen => Price < 0;
}