using RestaurantBooking.Application.Interfaces;

namespace RestaurantBooking.Api.Dispatchers;

public class CommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> DispatchAsync<TCommand, TResult>(
        TCommand command,
        CancellationToken ct = default)
        where TCommand : ICommand<TResult>
    {
        var handlerType = typeof(ICommandHandler<,>)
            .MakeGenericType(typeof(TCommand), typeof(TResult));

        var handler = _serviceProvider.GetRequiredService(handlerType);

        var method = handlerType.GetMethod("HandleAsync")
                     ?? throw new InvalidOperationException("HandleAsync not found");

        var task = (Task<TResult>)method.Invoke(handler, new object[] { command, ct })!;
        return await task;
    }
}