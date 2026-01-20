using RestaurantBooking.Application.Interfaces;

namespace RestaurantBooking.Application.Commands.CreateReservation;

public class CreateReservationCommand : ICommand<Guid>
{
    public Guid CustomerId { get; set; }
    public Guid RestaurantId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfGuests { get; set; }
}
