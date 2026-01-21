using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Api.Models.Requests;

public class CreateCustomerRequest
{
    [Required]
    public string Name { get; set; } = default!;

    [Required, EmailAddress]
    public string Email { get; set; } = default!;
    
    [Required]
    public string Phone { get; set; } = default!;
}