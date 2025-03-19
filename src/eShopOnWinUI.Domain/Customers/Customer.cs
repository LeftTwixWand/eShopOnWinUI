using eShopOnWinUI.Domain.Customers.Rules;
using eShopOnWinUI.Domain.SeedWork.Entities;
using eShopOnWinUI.Domain.Shipments;

namespace eShopOnWinUI.Domain.Customers;

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
        CheckRule(new CustomerFirstNameMustNotBeEmpty(firstName));
        CheckRule(new CustomerLastNameMustNotBeEmpty(lastName));
        CheckRule(new CustomerPhoneMustBeValid(phone));
        CheckRule(new CustomerEmailMustBeValid(email));

        return new Customer(CustomerId.Default, firstName, lastName, phone, middleName, email, shipment, picture);
    }
}