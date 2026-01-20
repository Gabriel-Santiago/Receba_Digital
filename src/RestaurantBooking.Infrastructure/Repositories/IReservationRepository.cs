using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Infrastructure.Repositories;

public interface IReservationRepository
{
    Task AddAsync(Reservation reservation);
    Task<List<Reservation>> GetAllAsync();
}
