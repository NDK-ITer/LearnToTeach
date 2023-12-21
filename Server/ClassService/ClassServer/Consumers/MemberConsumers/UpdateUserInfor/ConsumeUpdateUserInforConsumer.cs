using Application.Models.ModelsOfMember;
using Application.Services;
using Events.UserServiceEvents.DataSynchronization;
using MassTransit;

namespace ClassServer.Consumers.MemberConsumers.UpdateUserInfor
{
    public class ConsumeUpdateUserInforConsumer : IConsumer<IConsumeUserInforEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public ConsumeUpdateUserInforConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<IConsumeUserInforEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var memberModel = new UpdateMemberModel()
                {
                    idMember = data.IdUser.ToString(),
                    nameMember = data.FullName,
                    avatar = data.Avatar,
                    linkAvatar = data.LinkAvatar,
                };
                unitOfWork_ClassroomService._memberService.UpdateInforMember(memberModel);
            }
        }
    }
}
