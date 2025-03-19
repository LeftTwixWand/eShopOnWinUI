using eShopOnWinUI.Domain.OrderItems;
using eShopOnWinUI.Domain.SeedWork.BusinessRules;

namespace eShopOnWinUI.Domain.Orders.Rules;

internal sealed record OrderMustHaveAtLeastOneOrderItem(OrderItem[] OrderItems) : IBusinessRule
{
    public string Message => "Order must have at least one order item.";

    public bool BrokenWhen => OrderItems.Length < 1;
}