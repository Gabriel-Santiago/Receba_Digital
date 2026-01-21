using RestaurantBooking.Application.Interfaces;
using RestaurantBooking.Application.Interfaces.Repositories;
using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Commands.CreateCustomer;

public class CreateCustomerHandler
    : ICommandHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> HandleAsync(
        CreateCustomerCommand command,
        CancellationToken ct = default)
    {
        var customer = new Customer(
            command.Name,
            command.Email,
            command.Phone
        );

        await _repository.AddAsync(customer, ct);

        return customer.Id;
    }
}