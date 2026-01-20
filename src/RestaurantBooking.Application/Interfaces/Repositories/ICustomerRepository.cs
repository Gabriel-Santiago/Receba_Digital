using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int id, CancellationToken ct = default);
}