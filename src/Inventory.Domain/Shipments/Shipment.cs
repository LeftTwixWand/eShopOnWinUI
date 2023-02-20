﻿using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Countries;
using Inventory.Domain.Shipments.Events;
using Inventory.Domain.Shipments.Rules;

namespace Inventory.Domain.Shipments;

public sealed class Shipment : Entity
{
    private Shipment(ShipmentId id, string address, string city, string region, Country country, string postalCode, Status status, DateTimeOffset? shippedDate, DateTimeOffset? deliveredDate)
    {
        Id = id;
        Address = address;
        City = city;
        Region = region;
        Country = country;
        PostalCode = postalCode;
        Status = status;
        ShippedDate = shippedDate;
        DeliveredDate = deliveredDate;
    }

    public ShipmentId Id { get; private set; }

    public string Address { get; private set; }

    public string City { get; private set; }

    public string Region { get; private set; }

    public Country Country { get; private set; }

    public string PostalCode { get; private set; }

    public Status Status { get; private set; }

    public DateTimeOffset? ShippedDate { get; private set; }

    public DateTimeOffset? DeliveredDate { get; private set; }

    public static Shipment Create(string address, string city, string region, Country country, string postalCode, DateTimeOffset? shippedDate = default, DateTimeOffset? deliveredDate = default)
    {
        CheckRule(new ShipmentAddressMustNotBeEmptyRule(address));
        CheckRule(new ShipmentCityMustNotBeEmptyRule(city));
        CheckRule(new ShipmentRegionMustNotBeEmptyRule(region));
        CheckRule(new ShipmentPostalCodeMustNotBeEmptyRule(postalCode));
        CheckRule(new ShipmentPostalCodeMustContainsOnlyNumbersRule(postalCode));

        var shipment = new Shipment(ShipmentId.Default, address, city, region, country, postalCode, Status.Processing, shippedDate, deliveredDate);
        //shipment.AddDomainEvent(new ShipmentCreatedDomainEvent() )
        return shipment;
    }

    public void Ship(DateTimeOffset shippedDate)
    {
        Status = Status.Shipped;
        ShippedDate = shippedDate;

        AddDomainEvent(new ShipmentSentDomainEvent(Id));
    }

    public void Deliver(DateTimeOffset deliveredDate)
    {
        Status = Status.Delivered;
        DeliveredDate = deliveredDate;
    }
}