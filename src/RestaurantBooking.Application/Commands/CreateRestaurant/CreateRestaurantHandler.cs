using RestaurantBooking.Application.Interfaces;
using RestaurantBooking.Application.Interfaces.Repositories;
using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Commands.CreateRestaurant;

public class CreateRestaurantHandler
    : ICommandHandler<CreateRestaurantCommand, Guid>
{
    private readonly IRestaurantRepository _repository;

    public CreateRestaurantHandler(IRestaurantRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> HandleAsync(
        CreateRestaurantCommand command,
        CancellationToken ct = default)
    {
        var restaurant = new Restaurant(
            command.Name,
            command.Capacity
        );

        await _repository.AddAsync(restaurant, ct);

        return restaurant.Id;
    }
}
