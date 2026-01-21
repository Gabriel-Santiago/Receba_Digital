using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Application.Interfaces.Repositories;
using RestaurantBooking.Domain.Entities;
using RestaurantBooking.Infrastructure.Persistence;

namespace RestaurantBooking.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly BookingContext _context;

    public CustomerRepository(BookingContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Customers
            .FirstOrDefaultAsync(c => c.Id.Equals(id), ct);
    }
    
    public async Task AddAsync(Customer customer, CancellationToken ct = default)
    {
        await _context.Customers.AddAsync(customer, ct);
        await _context.SaveChangesAsync(ct);
    }

}