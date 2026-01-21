using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Api.Models.Requests;

public class CreateRestaurantRequest
{
    [Required]
    public string Name { get; set; } = default!;
    
    [Required]
    public int Capacity { get; set; } = default!;
}