using Events.UserServiceEvents;
using MassTransit;

namespace UserServer.Consumers
{
    public class GetValueUserEvent : IConsumer<IGetValueUserEvent>
    {
        public GetValueUserEvent()
        {
            
        }
        public async Task Consume(ConsumeContext<IGetValueUserEvent> context)
        {
            var data = context.Message;

        }
    }
}
