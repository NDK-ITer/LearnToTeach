using Events.ClassroomServiceEvents.Models;

namespace SagaStateMachine.ClassroomService.Member.AddMember
{
    public class MemberModel
    {
        public Guid idMemberModel { get; set; }
        public string IdMember { get; set; }
        public string? NameMember { get; set; }
        public string? Avatar { get; set; }
        public MemberEventModel ChangeToMemberEventModel()
        {
            var memberEventModel = new MemberEventModel()
            {
                IdMember = IdMember,
                NameMember = NameMember,
                Avatar = Avatar,
            };
            return memberEventModel;
        }
    }
}
