using Application.Models;
using MassTransit;

namespace ServiceComposition.Message
{
    public class UserConsumer : IConsumer<UserModel>
    {
        public object? UserMessage { get; private set; }
        public async Task Consume(ConsumeContext<UserModel> context)
        {
            UserMessage = context.Message;
        }
    }
}
