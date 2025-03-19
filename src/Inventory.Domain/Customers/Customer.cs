using Inventory.Domain.Customers.Rules;
using Inventory.Domain.SeedWork.Entities;
using Inventory.Domain.Shipments;

namespace Inventory.Domain.Customers;

public class Customer : Entity
{
    private Customer(CustomerId id, string firstName, string lastName, string phone, string? middleName, string email, Shipment? shipment, byte[]? picture)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Phone = phone;
        Email = email;
        Shipment = shipment;
        Picture = picture;
    }

    public CustomerId Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string? MiddleName { get; private set; }

    public string Phone { get; private set; }

    public string Email { get; private set; }

    public Shipment? Shipment { get; private set; }

    public byte[]? Picture { get; set; }

    public static Customer Create(string firstName, string lastName, string phone, string? middleName, string email, Shipment? shipment, byte[]? picture)
    {
        CheckRule(new CustomerFirstNameMustNotBeEmptyRule(firstName));
        CheckRule(new CustomerLastNameMustNotBeEmptyRule(lastName));
        CheckRule(new CustomerPhoneMustBeValidRule(phone));
        CheckRule(new CustomerEmailMustBeValidRule(email));

        return new Customer(CustomerId.Default, firstName, lastName, phone, middleName, email, shipment, picture);
    }
}