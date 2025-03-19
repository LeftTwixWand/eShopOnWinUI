namespace eShopOnWinUI.Domain.Customers;

public sealed record CustomerId(int Value)
{
    public static CustomerId Default => new(0);
}