namespace RestaurantBooking.Api.Models.Responses;

public class CreateRestaurantResponse
{
    public Guid CustomerId { get; set; }
    public String Name { get; set; }
    public int Capacity { get; set; }
}