using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Models;

namespace SagaStateMachine.ClassroomService.Member
{
    public class ConsumeValueAddMemberEvent : IConsumeValueMemberEvent
    {
        private readonly AddMemberStateData memberStateData;

        public ConsumeValueAddMemberEvent(AddMemberStateData memberStateData)
        {
            this.memberStateData = memberStateData;
        }
        public Guid idClassroom => memberStateData.IdClassroom;
        public List<MemberEventModel> ListMember => memberStateData.ListMember;
    }
}
