using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Api.Dispatchers;
using RestaurantBooking.Api.Models.Requests;
using RestaurantBooking.Api.Models.Responses;
using RestaurantBooking.Application.Commands.CreateCustomer;

namespace RestaurantBooking.Api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly CommandDispatcher _dispatcher;

    public CustomersController(CommandDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCustomerRequest request,
        CancellationToken ct)
    {
        var command = new CreateCustomerCommand
        {
            Name = request.Name,
            Email = request.Email
        };

        var id = await _dispatcher
            .DispatchAsync<CreateCustomerCommand, Guid>(command, ct);

        return Created(string.Empty, new CreateCustomerResponse { CustomerId = id });
    }
}