using RestaurantBooking.Application.Interfaces;

namespace RestaurantBooking.Application.Commands.CreateReservation;

public class CreateReservationCommand : ICommand<Guid>
{
    public int CustomerId { get; set; }
    public int RestaurantId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfGuests { get; set; }
}
