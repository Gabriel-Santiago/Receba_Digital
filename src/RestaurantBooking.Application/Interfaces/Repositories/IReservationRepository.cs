using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Interfaces.Repositories;

public interface IReservationRepository
{
    Task AddAsync(Reservation reservation, CancellationToken ct = default);
    Task<Reservation?> GetByCodeAsync(Guid code, CancellationToken ct = default);
}
