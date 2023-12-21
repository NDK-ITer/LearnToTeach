using Application.Models.ModelsOfMember;
using Application.Services;
using Events.ClassroomServiceEvents.Classroom.AddClassroom;
using MassTransit;

namespace ClassServer.Consumers.ClassroomConsumers.AddClassroom
{
    public class GenerateAddClassroomIsValidConsumer : IConsumer<IAddClassroomIsValidEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public GenerateAddClassroomIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<IAddClassroomIsValidEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var updateMemberModel = new UpdateMemberModel()
                {
                    idMember = data.idUserHost,
                    nameMember = data.nameUserHost,
                    avatar = data.avatarMember,
                    linkAvatar = data.linkAvatar,
                    email = data.email,
                };
                unitOfWork_ClassroomService._memberService.UpdateInforMember(updateMemberModel);
            }
        }
    }
}
