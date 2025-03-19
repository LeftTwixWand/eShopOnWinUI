using Inventory.Domain.OrderItems.Rules;
using Inventory.Domain.Products;
using Inventory.Domain.SeedWork.Entities;

namespace Inventory.Domain.OrderItems;

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
        CheckRule(new QuantityCanNotBeLessThanZeroRule(quantity));
        CheckRule(new PriceCanNotBeLessThanZeroRule(quantity));
        CheckRule(new DiscountCanNotBeLessThanZeroPercentsRule(discount));
        CheckRule(new DiscountCanNotBeMoreThanHundredPercentsRule(discount));

        return new OrderItem(OrderItemId.Default, quantity, unitPrice, discount)
        {
            Product = product,
        };
    }
}