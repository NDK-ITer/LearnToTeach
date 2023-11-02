using Events.ClassroomServiceEvents.Member;

namespace SagaStateMachine.ClassroomService.Member
{
    public class ConsumeValueMemberEvent : IConsumeValueMemberEvent
    {
        private readonly AddMemberStateData memberStateData;

        public ConsumeValueMemberEvent(AddMemberStateData memberStateData)
        {
            this.memberStateData = memberStateData;
        }
        public Guid idClassroom => memberStateData.IdClassroom;
        public string IdMember => memberStateData.IdMember;
    }
}
