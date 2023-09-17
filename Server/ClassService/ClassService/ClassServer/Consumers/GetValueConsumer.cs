using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace ClassServer.Consumers
{
    public class GetValueConsumer : IConsumer<IGetValueClassroomEvent>
    {
        public async Task Consume(ConsumeContext<IGetValueClassroomEvent> context)
        {
            var data = context.Message;
            if (data is not null)
            {
                // This section will publish message to the IAddTicketEvent although the GenerateTicket service has a consumer
                // that it will be listened on the IAddTicketEvent
                await context.Publish<IAddClassroomEvent>(new
                {
                    idClassroom = data.idClassroom,
                    description = data.description,
                    idUserHost = data.idUserHost,
                    name = data.name,
                    isPrivate = data.isPrivate
                });
            }
        }
    }
}
