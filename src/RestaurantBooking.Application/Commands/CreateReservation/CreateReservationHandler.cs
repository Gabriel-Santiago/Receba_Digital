using RestaurantBooking.Application.Interfaces;
using RestaurantBooking.Application.Interfaces.Repositories;
using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Application.Commands.CreateReservation;

public class CreateReservationHandler
    : ICommandHandler<CreateReservationCommand, Guid>
{
    private readonly IReservationRepository _repo;
    private readonly ICustomerRepository _customerRepo;
    private readonly IRestaurantRepository _restaurantRepo;

    public CreateReservationHandler(
        IReservationRepository repo,
        ICustomerRepository customerRepo,
        IRestaurantRepository restaurantRepo)
    {
        _repo = repo;
        _customerRepo = customerRepo;
        _restaurantRepo = restaurantRepo;
    }

    public async Task<Guid> HandleAsync(
        CreateReservationCommand cmd,
        CancellationToken ct = default)
    {
        var customer = await _customerRepo.GetByIdAsync(cmd.CustomerId, ct)
                       ?? throw new InvalidOperationException("Customer not found");

        var restaurant = await _restaurantRepo.GetByIdAsync(cmd.RestaurantId, ct)
                         ?? throw new InvalidOperationException("Restaurant not found");

        var reservation = new Reservation(
            customer,
            restaurant,
            cmd.ReservationDate,
            cmd.NumberOfGuests);

        await _repo.AddAsync(reservation);

        return reservation.Code;
    }
}
