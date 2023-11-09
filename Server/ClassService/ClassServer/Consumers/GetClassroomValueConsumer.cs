using ClassServer.Models;
using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace ClassServer.Consumers
{
    public class GetClassroomValueConsumer : IConsumer<IGetValueClassroomEvent>
    {
        private readonly ClassroomEventMessage classroomEventMessage;

        public GetClassroomValueConsumer(ClassroomEventMessage classroomEventMessage)
        {
            this.classroomEventMessage = classroomEventMessage;
        }
        public async Task Consume(ConsumeContext<IGetValueClassroomEvent> context)
        {
            var data = context.Message;
            if (data is not null)
            {
                if (data.eventMessage == classroomEventMessage.Create)
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
                else if (data.eventMessage == classroomEventMessage.Update)
                {
                    await context.Publish<IUpdateClassroomEvent>(new
                    {
                        idClassroom = data.idClassroom,
                        description = data.description,
                        name = data.name
                    });
                }
            }
        }
    }
}
