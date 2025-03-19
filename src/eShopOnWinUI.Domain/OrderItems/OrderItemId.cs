namespace eShopOnWinUI.Domain.OrderItems;

public sealed record OrderItemId(int Value)
{
    public static OrderItemId Default => new(0);
}