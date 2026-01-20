namespace RestaurantBooking.Domain.Events;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
