using Events.UserServiceEvents;
using Events.UserServiceEvents.User;
using MassTransit;
using UserServer.Models;

namespace UserServer.Consumers
{
    public class GetValueUserConsumer : IConsumer<IGetValueUserEvent>
    {
        private readonly UserEventMessage _userEventMessage;

        public GetValueUserConsumer(UserEventMessage userEventMessage)
        {
            _userEventMessage = userEventMessage;
        }
        public async Task Consume(ConsumeContext<IGetValueUserEvent> context)
        {
            var data = context.Message;
            if (data != null) 
            {
                if (data.eventMessage == _userEventMessage.ConfirmAccount)
                {
                    await context.Publish<IConfirmUserEvent>(new
                    {
                        idUser = data.id,
                        fullName = data.fullName,
                        email = data.email,
                        subject = data.subject,
                        content = data.content,
                    });
                }
            }
            
        }
    }
}
