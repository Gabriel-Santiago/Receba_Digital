using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Application.Interfaces.Repositories;
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

    public async Task AddAsync(Reservation reservation, CancellationToken ct = default)
    {
        await _context.Reservations.AddAsync(reservation, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<Reservation?> GetByCodeAsync(Guid code, CancellationToken ct = default)
    {
        return await _context.Reservations
            .FirstOrDefaultAsync(r => r.Code == code, ct);
    }
}
