using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.OrderItems.Rules;

internal sealed record DiscountCanNotBeLessThanZeroPercentsRule(decimal Discount) : IBusinessRule
{
    public string Message => "Discount can not be less than zero percent.";

    public bool BrokenWhen => Discount < 0;
}