using ClassServer.Models;
using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Member.AddMember;
using Events.ClassroomServiceEvents.Models;
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
                if (data.eventMessage == classroomEventMessage.AddMember)
                {
                    var listMember = new List<MemberEventModel>();
                    foreach (var item in data.ListIdMember)
                    {
                        listMember.Add(new MemberEventModel()
                        {
                            IdMember = item,
                            Avatar = "",
                            NameMember = ""
                        });
                    }
                    await context.Publish<IAddMemberEvent>(new
                    {
                        IdClassroom = data.IdClassroom,
                        NameClassroom = data.NameClassroom,
                        ListMember = listMember,
                    });
                }
            }
        }
    }
}
