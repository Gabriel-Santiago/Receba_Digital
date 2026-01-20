using RestaurantBooking.Domain.Commom;
using RestaurantBooking.Domain.Exceptions;

namespace RestaurantBooking.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    protected Customer() { }

    public Customer(string name, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Customer name is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Customer email is required");

        Name = name;
        Email = email;
        Phone = phone;
    }
}
