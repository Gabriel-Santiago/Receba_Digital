using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Domain.Events;

public class ReservationCreatedEvent : IDomainEvent
{
    public Reservation Reservation { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public ReservationCreatedEvent(Reservation reservation)
    {
        Reservation = reservation;
    }
}
