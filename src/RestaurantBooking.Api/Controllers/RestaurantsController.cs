using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Api.Dispatchers;
using RestaurantBooking.Api.Models.Requests;
using RestaurantBooking.Application.Commands.CreateRestaurant;

namespace RestaurantBooking.Api.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController : ControllerBase
{
    private readonly CommandDispatcher _dispatcher;

    public RestaurantsController(CommandDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateRestaurantRequest request,
        CancellationToken ct)
    {
        var command = new CreateRestaurantCommand
        {
            Name = request.Name
        };

        var id = await _dispatcher
            .DispatchAsync<CreateRestaurantCommand, Guid>(command, ct);

        return Created(string.Empty, new { RestaurantId = id });
    }
}
