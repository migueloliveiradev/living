using Living.Domain.Features.Users.Events;
using Living.Domain.Features.Users.Interfaces;
using MassTransit;

namespace Living.Worker.Queue;
public class UserCreatedConsumer(IUserRepository userRepository) : IConsumer<UserCreatedEvent>
{
    public Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        Console.WriteLine($"User created: {context.Message.UserId}");

        return Task.CompletedTask;
    }
}
