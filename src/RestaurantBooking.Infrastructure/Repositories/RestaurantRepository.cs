using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Application.Interfaces.Repositories;
using RestaurantBooking.Domain.Entities;
using RestaurantBooking.Infrastructure.Persistence;

namespace RestaurantBooking.Infrastructure.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly BookingContext _context;

    public RestaurantRepository(BookingContext context)
    {
        _context = context;
    }

    public async Task<Restaurant?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Restaurants
            .FirstOrDefaultAsync(r => r.Id.Equals(id), ct);
    }
    
    public async Task AddAsync(Restaurant restaurant, CancellationToken ct = default)
    {
        await _context.Restaurants.AddAsync(restaurant, ct);
        await _context.SaveChangesAsync(ct);
    }
}