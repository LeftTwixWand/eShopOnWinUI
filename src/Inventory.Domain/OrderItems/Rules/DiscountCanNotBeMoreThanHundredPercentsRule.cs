using Inventory.Domain.SeedWork.BusinessRules;

namespace Inventory.Domain.OrderItems.Rules;

internal sealed record DiscountCanNotBeMoreThanHundredPercentsRule(decimal Discount) : IBusinessRule
{
    public string Message => "Discount can not be more than hundred percent.";

    public bool BrokenWhen => Discount > 100;
}