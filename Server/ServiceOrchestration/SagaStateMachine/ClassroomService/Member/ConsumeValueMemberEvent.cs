using Events.ClassroomServiceEvents.Member;

namespace SagaStateMachine.ClassroomService.Member
{
    public class ConsumeValueMemberEvent : IConsumeValueMemberEvent
    {
        private readonly MemberStateData memberStateData;

        public ConsumeValueMemberEvent(MemberStateData memberStateData)
        {
            this.memberStateData = memberStateData;
        }
        public Guid idClassroom => memberStateData.IdClassroom;
        public string? IdMember => memberStateData.IdMember;
    }
}
