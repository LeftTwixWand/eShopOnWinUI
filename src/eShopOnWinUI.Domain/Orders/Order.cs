using eShopOnWinUI.Domain.Customers;
using eShopOnWinUI.Domain.OrderItems;
using eShopOnWinUI.Domain.Orders.Rules;
using eShopOnWinUI.Domain.SeedWork.AggregateRoots;
using eShopOnWinUI.Domain.SeedWork.Entities;
using eShopOnWinUI.Domain.Shipments;

namespace eShopOnWinUI.Domain.Orders;

public sealed class Order : Entity, IAggregateRoot
{
    private readonly List<OrderItem> _orderItems = [];

    private Order(OrderId id, DateTimeOffset orderDate, PaymentType paymentType, Shipment? shipment)
    {
        Id = id;
        OrderDate = orderDate;
        PaymentType = paymentType;
        Shipment = shipment;
        Customer = default!;
    }

    public OrderId Id { get; private set; }

    public DateTimeOffset OrderDate { get; private set; }

    public PaymentType PaymentType { get; private set; }

    public Customer Customer { get; private set; }

    public Shipment? Shipment { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public static Order Create(DateTimeOffset orderDate, PaymentType paymentType, Customer customer, Shipment? shipment, params OrderItem[] orderItems)
    {
        CheckRule(new OrderMustHaveAtLeastOneOrderItem(orderItems));
        CheckRule(new ShipmentMustNotBeEmptyIfOrderHasPaymentOnDelivery(paymentType, shipment));

        var order = new Order(OrderId.New, orderDate, paymentType, shipment)
        {
            Customer = customer,
        };

        order._orderItems.AddRange(orderItems);

        return order;
    }
}