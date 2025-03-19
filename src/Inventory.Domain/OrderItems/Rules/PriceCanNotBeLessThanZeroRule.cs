using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.OrderItems.Rules;

internal sealed record PriceCanNotBeLessThanZeroRule(decimal Price) : IBusinessRule
{
    public string Message => "Price can not be less than zero.";

    public bool BrokenWhen => Price < 0;
}