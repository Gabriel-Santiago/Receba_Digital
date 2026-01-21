using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Customer customer, CancellationToken ct = default);
}