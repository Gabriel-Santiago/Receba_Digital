using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Api.Models.Requests;

public class CreateReservationRequest
{
    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public Guid RestaurantId { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    [Range(1, 20)]
    public int NumberOfGuests { get; set; }
}