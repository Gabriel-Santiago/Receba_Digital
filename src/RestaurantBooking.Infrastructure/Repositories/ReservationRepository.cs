using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Domain.Entities;
using RestaurantBooking.Infrastructure.Persistence;

namespace RestaurantBooking.Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly BookingContext _context;

    public ReservationRepository(BookingContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
    }

    public Task<List<Reservation>> GetAllAsync()
        => _context.Reservations.ToListAsync();
}
