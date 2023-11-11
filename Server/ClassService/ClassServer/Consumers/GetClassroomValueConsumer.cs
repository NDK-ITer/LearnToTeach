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
                await context.Publish<IClassroomEvent>(new
                {
                    idClassroom = data.idClassroom,
                    description = data.description,
                    idUserHost = data.idUserHost,
                    name = data.name,
                    isPrivate = data.isPrivate,
                    eventMessage = data.eventMessage,
                });
            }
        }
    }
}
