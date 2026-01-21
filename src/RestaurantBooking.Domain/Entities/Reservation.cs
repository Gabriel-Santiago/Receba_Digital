using RestaurantBooking.Domain.Commom;
using RestaurantBooking.Domain.Exceptions;
using RestaurantBooking.Domain.ValueObjects;

namespace RestaurantBooking.Domain.Entities;

public class Reservation : AggregateRoot
{
    public Guid Code { get; private set; }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }

    public Guid RestaurantId { get; private set; }
    public Restaurant Restaurant { get; private set; }

    public DateTime ReservationDate { get; private set; }
    public int NumberOfGuests { get; private set; }
    public ReservationStatus Status { get; private set; }

    protected Reservation() { }

    public Reservation(
        Customer customer,
        Restaurant restaurant,
        DateTime reservationDate,
        int numberOfGuests)
    {
        if (numberOfGuests <= 0)
            throw new DomainException("Number of guests must be greater than zero");

        if (reservationDate <= DateTime.UtcNow)
            throw new DomainException("Reservation date must be in the future");

        Customer = customer ?? throw new DomainException("Customer is required");
        Restaurant = restaurant ?? throw new DomainException("Restaurant is required");

        CustomerId = customer.Id;
        RestaurantId = restaurant.Id;

        ReservationDate = reservationDate;
        NumberOfGuests = numberOfGuests;

        Code = Guid.NewGuid();
        Status = ReservationStatus.PENDING;
    }

    public void Confirm()
    {
        if (!Status.Equals(ReservationStatus.PENDING))
            throw new DomainException("Only pending reservations can be confirmed");

        Status = ReservationStatus.CONFIRMED;
    }

    public void CheckIn()
    {
        if (!Status.Equals(ReservationStatus.CONFIRMED))
            throw new DomainException("Only confirmed reservations can be checked in");

        Status = ReservationStatus.CHECKED_IN;
    }

    public void MarkAsNoShow()
    {
        if (!Status.Equals(ReservationStatus.CONFIRMED))
            throw new DomainException("Only confirmed reservations can be marked as no-show");

        Status = ReservationStatus.NO_SHOW;
    }
}
