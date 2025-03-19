using Inventory.Domain.Customers;
using Inventory.Domain.OrderItems;
using Inventory.Domain.Orders.Rules;
using Inventory.Domain.SeedWork.AggregateRoots;
using Inventory.Domain.SeedWork.Entities;
using Inventory.Domain.Shipments;

namespace Inventory.Domain.Orders;

public sealed class Order : Entity, IAggregateRoot
{
    private readonly List<OrderItem> _orderItems = new();

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
        CheckRule(new OrderMustHaveAtLeastOneOrderItemRule(orderItems));
        CheckRule(new ShipmentMustNotBeEmptyIfOrderHasPaymentOnDeliveryRule(paymentType, shipment));

        var order = new Order(OrderId.New, orderDate, paymentType, shipment)
        {
            Customer = customer,
        };

        order._orderItems.AddRange(orderItems);

        return order;
    }
}