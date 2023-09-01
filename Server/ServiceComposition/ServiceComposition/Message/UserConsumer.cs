using MassTransit;
using ModelObject.UserService.Models;

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
