using RestaurantBooking.Application.Interfaces;

namespace RestaurantBooking.Application.Commands.CreateRestaurant;

public class CreateRestaurantCommand : ICommand<Guid>
{
    public string Name { get; init; } = default!;

    public int Capacity { get; init; } = default!;
}
