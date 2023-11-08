using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Models;
using SagaStateMachine.ClassroomService.Member.AddMember;

namespace SagaStateMachine.ClassroomService.Member
{
    public class ConsumeValueAddMemberEvent : IConsumeValueMemberEvent
    {
        private readonly AddMemberStateData memberStateData;
        private List<MemberEventModel> ChangeToListMemberEventModel(List<MemberModel> memberModel)
        {
            var listMemberEventModel = new List<MemberEventModel>();
            foreach (var item in memberModel)
            {
                listMemberEventModel.Add(item.ChangeToMemberEventModel());
            }
            return listMemberEventModel;
        }
        public ConsumeValueAddMemberEvent(AddMemberStateData memberStateData)
        {
            this.memberStateData = memberStateData;
        }
        public Guid idClassroom => memberStateData.IdClassroom;
        public List<MemberEventModel> ListMember => ChangeToListMemberEventModel(memberStateData.ListMember);
        public string NameClassroom => memberStateData.NameClassroom;
    }
}
