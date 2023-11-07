using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Member;
using MassTransit;

namespace ClassServer.Consumers
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
                foreach (var item in data.ListMember)
                {
                    var memberModel = new MemberModel()
                    {
                        idMember = item.IdMember,
                        avatar = item.Avatar,
                        nameMember = item.NameMember,
                        role = null,
                        description = null
                    };
                    var updateInforMember = unitOfWork_ClassroomService._memberService.UpdateInforMember(memberModel);
                }
                
            }
        }
    }
}
