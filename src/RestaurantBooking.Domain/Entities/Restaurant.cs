using RestaurantBooking.Domain.Commom;
using RestaurantBooking.Domain.Exceptions;

namespace RestaurantBooking.Domain.Entities;

public class Restaurant : Entity
{
    public string Name { get; private set; }
    public int Capacity { get; private set; }

    protected Restaurant() { }

    public Restaurant(string name, int capacity)
    {
        if (capacity <= 0)
            throw new DomainException("Restaurant capacity must be greater than zero");

        Name = name;
        Capacity = capacity;
    }
}
