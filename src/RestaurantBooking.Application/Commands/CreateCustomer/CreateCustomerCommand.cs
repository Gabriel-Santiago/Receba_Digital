using RestaurantBooking.Application.Interfaces;

namespace RestaurantBooking.Application.Commands.CreateCustomer;

public class CreateCustomerCommand : ICommand<Guid>
{
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Phone { get; init; } = default!;
}