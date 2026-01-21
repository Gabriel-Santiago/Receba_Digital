using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Interfaces.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Restaurant restaurant, CancellationToken ct = default);
}