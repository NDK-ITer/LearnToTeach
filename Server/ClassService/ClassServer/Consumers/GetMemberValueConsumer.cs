using ClassServer.Models;
using Domain.Entities;
using Events.ClassroomServiceEvents.Member;
using MassTransit;

namespace ClassServer.Consumers
{
    public class GetMemberValueConsumer : IConsumer<IGetValueMemberEvent>
    {
        private readonly ClassroomEventMessage classroomEventMessage;

        public async Task Consume(ConsumeContext<IGetValueMemberEvent> context)
        {
            var data = context.Message;
            if (data is not null)
            {
                if (data.eventMessage == classroomEventMessage.AddMember)
                {
                    await context.Publish<IAddMemberEvent>(new
                    {
                        IdClassroom = data.IdClassroom,
                        IdMember = data.IdMember,
                    });
                }
            }
        }
    }
}
