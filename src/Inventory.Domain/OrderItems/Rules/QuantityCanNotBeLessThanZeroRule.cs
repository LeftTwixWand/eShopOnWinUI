using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.OrderItems.Rules;

internal sealed record QuantityCanNotBeLessThanZeroRule(decimal Quantity) : IBusinessRule
{
    public string Message => "Quantity can not be less than zero.";

    public bool BrokenWhen => Quantity < 0;
}