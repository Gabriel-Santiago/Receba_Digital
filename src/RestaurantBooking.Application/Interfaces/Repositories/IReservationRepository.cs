using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Interfaces.Repositories;

public interface IReservationRepository
{
    Task AddAsync(Reservation reservation);
    Task<List<Reservation>> GetAllAsync();
    
    Task<Reservation?> GetByCodeAsync(Guid code, CancellationToken ct = default);
}
