using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Member.AddMember;
using MassTransit;

namespace ClassServer.Consumers.AddMember
{
    public class GenerateAddMemberIsValidConsumer : IConsumer<IAddMemberIsValidEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public GenerateAddMemberIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }

        public async Task Consume(ConsumeContext<IAddMemberIsValidEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var memberModel = new MemberModel()
                {
                    idMember = data.IdMember,
                    avatar = data.Avatar,
                    nameMember = data.NameMember,
                    role = null,
                    description = null,
                };
                var updateInforMember = unitOfWork_ClassroomService._memberService.UpdateInforMember(memberModel);

            }
        }
    }
}
