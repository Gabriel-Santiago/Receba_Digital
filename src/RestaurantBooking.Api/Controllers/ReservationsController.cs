using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Api.Dispatchers;
using RestaurantBooking.Api.Models.Requests;
using RestaurantBooking.Api.Models.Responses;
using RestaurantBooking.Application.Commands.CreateReservation;

namespace RestaurantBooking.Api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    private readonly CommandDispatcher _dispatcher;

    public ReservationsController(CommandDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateReservationRequest request,
        CancellationToken ct)
    {
        var command = new CreateReservationCommand
        {
            CustomerId = request.CustomerId,
            RestaurantId = request.RestaurantId,
            ReservationDate = request.ReservationDate,
            NumberOfGuests = request.NumberOfGuests
        };

        var reservationCode = await _dispatcher
            .DispatchAsync<CreateReservationCommand, Guid>(command, ct);

        var response = new CreateReservationResponse
        {
            ReservationCode = reservationCode
        };

        return Created(string.Empty, response);
    }
}