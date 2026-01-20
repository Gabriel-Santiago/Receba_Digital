using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Interfaces.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant?> GetByIdAsync(int id, CancellationToken ct = default);
}