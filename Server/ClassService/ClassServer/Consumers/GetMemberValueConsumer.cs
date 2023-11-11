using ClassServer.Models;
using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Member.AddMember;
using MassTransit;

namespace ClassServer.Consumers
{
    public class GetMemberValueConsumer : IConsumer<IGetValueMemberEvent>
    {
        private readonly ClassroomEventMessage classroomEventMessage;
        public GetMemberValueConsumer(ClassroomEventMessage classroomEventMessage)
        {
            this.classroomEventMessage = classroomEventMessage;
        }
        public async Task Consume(ConsumeContext<IGetValueMemberEvent> context)
        {
            var data = context.Message;
            
            if (data is not null)
            {
                await context.Publish<IMemberEvent>(new
                {
                    IdClassroom = data.IdClassroom,
                    IdMember = data.IdMember,
                    NameClassroom = data.NameClassroom,
                    NameMember = data.NameMember,
                    Avatar = data.Avatar,
                    Event = data.eventMessage
                });
            }
        }
    }
}
