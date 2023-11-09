using Events.ClassroomServiceEvents.Member;

namespace SagaStateMachine.ClassroomService.Member.AddMember
{
    public class ConsumeValueAddMemberEvent : IConsumeValueMemberEvent
    {
        private readonly AddMemberStateData memberStateData;
        public ConsumeValueAddMemberEvent(AddMemberStateData memberStateData)
        {
            this.memberStateData = memberStateData;
        }
        public Guid idClassroom => memberStateData.IdClassroom;
        public string NameClassroom => memberStateData.NameClassroom;
        public string NameMember => memberStateData.NameMember;
        public string Avatar => memberStateData.Avatar;
    }
}
