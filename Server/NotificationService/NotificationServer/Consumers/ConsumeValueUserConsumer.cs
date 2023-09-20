using Event.UserEvents;
using MassTransit;

namespace NotificationServer.Consumers
{
    public class ConsumeValueUserConsumer : IConsumer<IConsumeValueUserEvent>
    {
        public async Task Consume(ConsumeContext<IConsumeValueUserEvent> context)
        {
        }
    }
}
