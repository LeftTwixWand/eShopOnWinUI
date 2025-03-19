using eShopOnWinUI.Domain.OrderItems.Rules;
using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.SeedWork.Entities;

namespace eShopOnWinUI.Domain.OrderItems;

public sealed class OrderItem : Entity
{
    private OrderItem(OrderItemId id, decimal quantity, decimal unitPrice, decimal discount)
    {
        Id = id;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
        Product = default!;
    }

    public OrderItemId Id { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal Discount { get; private set; }

    public Product Product { get; private set; }

    public static OrderItem Create(Product product, decimal quantity, decimal unitPrice, decimal discount = 0)
    {
        CheckRule(new QuantityCanNotBeLessThanZero(quantity));
        CheckRule(new PriceCanNotBeLessThanZero(quantity));
        CheckRule(new DiscountCanNotBeLessThanZeroPercent(discount));
        CheckRule(new DiscountCanNotBeMoreThanHundredPercent(discount));

        return new OrderItem(OrderItemId.Default, quantity, unitPrice, discount)
        {
            Product = product,
        };
    }
}